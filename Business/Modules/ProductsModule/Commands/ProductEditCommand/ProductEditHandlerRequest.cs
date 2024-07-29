using Infrastructure.Entities;
using Infrastructure.Extensions;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using Infrastructure.Services.Concretes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Commands.ProductEditCommand
{
    internal class ProductEditHandlerRequest(IProductRepository productRepository, IPictureRepository pictureRepository, IFileService fileService, IProductToSizeRepository productToSizeRepository, IProductToColorRepository productToColorRepository) : IRequestHandler<ProductEditRequest, Product>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IProductToSizeRepository _productToSizeRepository=productToSizeRepository;
        private readonly IProductToColorRepository _productToColorRepository=productToColorRepository;
        private readonly IPictureRepository _pictureRepository = pictureRepository;
        private readonly IFileService _fileService = fileService;
        public async Task<Product> Handle(ProductEditRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _productRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            dbData.Name = request.Name;
            dbData.Description = request.Description;
            dbData.Price = request.Price;
            dbData.Discount = request.Discount;
            dbData.Weight = request.Weight;
            dbData.Shipping = request.Shipping;
            dbData.Slug = request.Name.ToSlug();
            dbData.IsAvailability = request.IsAvailability;
            dbData.IsFeatured = request.IsFeatured;
            dbData.CategoryId=request.CategoryId;
            var existingSizes = await _productToSizeRepository.GetAllAsync(x=>x.ProductId==request.Id && x.DeletedBy==null);
            var existingColors= await _productToColorRepository.GetAllAsync(x=>x.ProductId==request.Id && x.DeletedBy==null);
            await _productToColorRepository.DeleteRange([.. existingColors]);
            await _productToSizeRepository.DeleteRange([.. existingSizes]);
            if(request.SizeIds is { } && request.SizeIds.Count > 0)
            {
                foreach (var item in request.SizeIds)
                {
                    await _productToSizeRepository.Add(new ProductToSize { ProductId = request.Id, SizeId = item });
                }
            }
            if (request.ColorIds is { } && request.ColorIds.Count > 0)
            {
                foreach (var item in request.ColorIds)
                {
                    await _productToColorRepository.Add(new ProductToColor { ProductId = request.Id, ColorId = item });
                }
            }
            List<int> removeImageIds = [];
            //List<Picture> dbIndelibleImages = [];
            if (request.removeImageIds is { })
            {
               removeImageIds=request.removeImageIds.Split("-").Select(x=>int.Parse(x)).ToList();
                List<Picture> removeImages = [];
                foreach (var item in removeImageIds)
                {
                    var dbRemoveImage = await _pictureRepository.GetAsync(x => x.Id == item && x.DeletedBy == null);
                    //dbIndelibleImages.Add(await _pictureRepository.GetAsync(x=>x.Id !=item && x.DeletedBy == null));
                    await _fileService.DeleteFileChangeAsync(null, dbRemoveImage.ImageUrl, true);
                    removeImages.Add(dbRemoveImage);
                }
               await _pictureRepository.DeleteRange(removeImages);
            }
            var existingPicture = await _pictureRepository.GetAllAsync(x => x.ProductId==request.Id && x.DeletedBy==null);
            var ProductImages = request.ProductImages;
            if (ProductImages is { })
            {
             dbData.ProductPictures =[];
                for (var i = 0; i < ProductImages.Count; i++)
                {
                    var isMain = i == 0 && !existingPicture.Any(x => x.IsMain);

                    var picture = new Picture
                    {
                        ProductId = request.Id,
                        ImageUrl = await _fileService.UploadFileAsync(ProductImages[i]),
                        IsMain = isMain
                    };
                    dbData.ProductPictures.Add(picture);
                }
                foreach (var image in dbData.ProductPictures)
                {
                    await _pictureRepository.Add(image);
                }
            }
            else
            {
                if(!existingPicture.Any(x => x.IsMain))
                {
                    var firstElement=existingPicture.First();
                    firstElement.IsMain = true;
                    dbData.ProductPictures = [.. existingPicture];
                }
            }
            await _productRepository.SaveAsync();
            return dbData;
        }
    }
}

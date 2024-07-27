using Infrastructure.Entities;
using Infrastructure.Extensions;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Commands.ProductAddCommand
{
    internal class ProductAddHandlerRequest(IProductRepository productRepository, IFileService fileService) : IRequestHandler<ProductAddRequest,Product>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IFileService _fileService = fileService;
        public async Task<Product> Handle(ProductAddRequest request, CancellationToken cancellationToken)
        {
            var newData = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                Discount = request.Discount,
                Weight = request.Weight,
                Description = request.Description,
                Slug = request.Name.ToSlug(),
                IsAvailability = request.IsAvailability,
                IsFeatured = request.IsFeatured,
                Shipping = request.Shipping,
                CategoryId = request.CategoryId,
                ProductToSizes = [],
                ProductToColors = [],
                ProductPictures = [],
            };
            if (request.SizeIds is { })
            {
                foreach (var sizeId in request.SizeIds)
                {
                    newData.ProductToSizes.Add(new ProductToSize { ProductId = newData.Id, SizeId = sizeId });
                }
            }
            if (request.ColorIds is { })
            {
                foreach (var colorId in request.ColorIds)
                {
                    newData.ProductToColors.Add(new ProductToColor { ProductId = newData.Id, ColorId = colorId });
                }
            }
            var ProductImages = request.ProductImages;
            if (request.ProductImages is { })
            {
                for (var i = 0; i < ProductImages.Count; i++)
                {
                    newData.ProductPictures.Add(
                        new Picture
                        {
                            ProductId = newData.Id,
                            ImageUrl = await _fileService.UploadFileAsync(ProductImages[0]),
                            IsMain = i is 0,
                        }
                       );
                }
            }
            await _productRepository.Add( newData );
            return newData;

        }
    }
}

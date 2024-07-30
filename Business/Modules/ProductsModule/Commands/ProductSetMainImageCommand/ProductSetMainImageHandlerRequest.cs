using Business.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Business.Modules.ProductsModule.Queries.ProductGetQuery;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Commands.ProductSetMainImageCommand
{
    internal class ProductSetMainImageHandlerRequest(IProductRepository productRepository, IPictureRepository pictureRepository, ICategoryRepository categoryRepository = null, IColorRepository colorRepository = null, ISizeRepository sizeRepository = null) : IRequestHandler<ProductSetMainImageRequest, ProductGetDto>
    {

        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IColorRepository _colorRepository = colorRepository;
        private readonly IPictureRepository _pictureRepository = pictureRepository;
        private readonly ISizeRepository _sizeRepository = sizeRepository;
        public async Task<ProductGetDto> Handle(ProductSetMainImageRequest request, CancellationToken cancellationToken)
        {
            var oldMainPhoto= await _pictureRepository.GetAsync(x=>x.ProductId==request.Id && x.IsMain==true && x.DeletedBy==null);
            oldMainPhoto.IsMain = false;
            var newMainPhoto=await _pictureRepository.GetAsync(x=>x.ProductId==request.Id && x.Id==request.MainPhotoId && x.IsMain!=true && x.DeletedBy==null);
            newMainPhoto.IsMain = true;
            await _pictureRepository.SaveAsync();
            var productList = await _productRepository.GetAllAsync(x => x.DeletedBy == null);
            var categoryList = await _categoryRepository.GetAllAsync();
            var pictureList = await _pictureRepository.GetAllAsync(x => x.DeletedBy == null);
            var colorList = await _colorRepository.GetAllAsync();
            var sizeList = await _sizeRepository.GetAllAsync();
            var dbData = (from pr in productList
                          join ct in categoryList on pr.CategoryId equals ct.Id
                          join i in pictureList on pr.Id equals i.ProductId into images
                          where pr.Id == request.Id
                          select new ProductGetDto
                          {
                              Id = pr.Id,
                              Name = pr.Name,
                              Price = pr.Price,
                              Discount = pr.Discount,
                              Weight = pr.Weight,
                              Shipping = pr.Shipping,
                              Description = pr.Description,
                              CategoryId = ct.Id,
                              CategoryName = ct.Name,
                              IsAvailability = pr.IsAvailability,
                              IsFeatured = pr.IsFeatured,
                              ProductImages = images.ToList(),
                              ProductColors = (from pc in pr.ProductToColors
                                               join c in colorList on pc.ColorId equals c.Id
                                               select c).ToList(),
                              ProductSizes = (from ps in pr.ProductToSizes
                                              join s in sizeList on ps.SizeId equals s.Id
                                              select s).ToList(),
                              CreatedBy = pr.CreatedBy,
                              CreatedAt = pr.CreatedAt,
                              UpdatedBy = pr.UpdatedBy,
                              UpdatedAt = pr.UpdatedAt,
                          }).FirstOrDefault();
            return dbData;
        }
    }
}

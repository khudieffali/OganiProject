using Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using Infrastructure.Repositroies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    internal class ProductGetAllHandlerRequest(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IPictureRepository pictureRepository) : IRequestHandler<ProductGetAllRequest, IEnumerable<ProductGetAllDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IPictureRepository _pictureRepository = pictureRepository;

        public async Task<IEnumerable<ProductGetAllDto>> Handle(ProductGetAllRequest request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllAsync(x => x.DeletedBy == null);
            var categoryList = await _categoryRepository.GetAllAsync();
            var pictureList = await _pictureRepository.GetAllAsync(x => x.DeletedBy == null);
            var dbDataList = (from pr in productList
                              join ct in categoryList on pr.CategoryId equals ct.Id
                              join pic in pictureList on pr.Id equals pic.ProductId
                              where pic.IsMain == true
                              select new ProductGetAllDto
                              {
                                  Id = pr.Id,
                                  Name = pr.Name,
                                  Price = pr.Price,
                                  Discount = pr.Discount,
                                  Description = pr.Description,
                                  Weight = pr.Weight,
                                  Shipping = pr.Shipping,
                                  IsAvailability = pr.IsAvailability,
                                  IsFeatured = pr.IsFeatured,
                                  CategoryId = ct.Id,
                                  CategoryName = ct.Name,
                                  MainPhoto = pic.ImageUrl,
                                  MainPhotoId = pic.Id,
                              }
                        );
            return [.. dbDataList];
        }
    }
}

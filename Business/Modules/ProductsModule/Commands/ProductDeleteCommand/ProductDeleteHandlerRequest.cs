using Business.Modules.ProductsModule.Queries.ProductGetAllQuery;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Commands.ProductDeleteCommand
{
    internal class ProductDeleteHandlerRequest(IProductRepository productRepository, ICategoryRepository categoryRepository, IPictureRepository pictureRepository, IFileService fileService) : IRequestHandler<ProductDeleteRequest, IEnumerable<ProductGetAllDto>>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IPictureRepository _pictureRepository = pictureRepository;
        private readonly IFileService _fileService = fileService;


        public async Task<IEnumerable<ProductGetAllDto>> Handle(ProductDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _productRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            var dbPictureList= await _pictureRepository.GetAllAsync(x=>x.ProductId==request.Id && x.DeletedBy==null);
            var dbProductList = await _productRepository.GetAllAsync(x => x.DeletedBy == null);
            if (dbPictureList is { })
            {
                foreach (var item in dbPictureList)
                {
                    await _fileService.DeleteFileChangeAsync(null, item.ImageUrl, true);
                }
            }
            await _productRepository.Delete(dbData);
            await _pictureRepository.DeleteRange([..dbPictureList]);
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

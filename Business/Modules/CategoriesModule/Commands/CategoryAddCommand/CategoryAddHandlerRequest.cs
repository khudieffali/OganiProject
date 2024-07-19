using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    internal class CategoryAddHandlerRequest(ICategoryRepository categoryRepository, IFileService fileService) : IRequestHandler<CategoryAddRequest, Category>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IFileService _fileService=fileService;
        public async Task<Category> Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var newData = new Category { Name = request.Name, 
                ImageUrl = request.ImageUrl==null?null : await _fileService.UploadFileAsync(request.ImageUrl),
                ParentId = request.ParentId 
            };
            await _categoryRepository.Add(newData);
            return newData;
        }
    }
}

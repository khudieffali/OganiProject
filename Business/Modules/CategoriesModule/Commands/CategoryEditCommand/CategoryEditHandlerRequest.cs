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

namespace Business.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    internal class CategoryEditHandlerRequest(ICategoryRepository categoryRepository, IFileService fileService) : IRequestHandler<CategoryEditRequest, Category>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IFileService _fileService=fileService;
        public async Task<Category> Handle(CategoryEditRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _categoryRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            dbData.Name = request.Name;
            dbData.Slug = request.Name.ToSlug();
            dbData.ImageUrl =request.ImageUrl==null?dbData.ImageUrl:await _fileService.UpdateFileChangeAsync(request.ImageUrl,dbData.ImageUrl,true) ;
            await _categoryRepository.SaveAsync();
            return dbData;
        }
    }
}

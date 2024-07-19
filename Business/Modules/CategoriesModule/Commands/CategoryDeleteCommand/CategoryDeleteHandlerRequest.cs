using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Commands.CategoryDeleteCommand
{
    internal class CategoryDeleteHandlerRequest(ICategoryRepository categoryRepository, IFileService fileService) : IRequestHandler<CategoryDeleteRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IFileService _fileService = fileService;

        public async Task<IEnumerable<Category>> Handle(CategoryDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _categoryRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            if (dbData.ImageUrl != null){
                dbData.ImageUrl = await _fileService.DeleteFileChangeAsync(null, dbData.ImageUrl);
            };
            await _categoryRepository.Delete(dbData);
            var dbDataList= await _categoryRepository.GetAllAsync(x=>x.DeletedBy==null);
            return [..dbDataList];
        }
    }
}

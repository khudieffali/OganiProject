using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Queries.CategoryGetAllQuery
{
    internal class CategoryGetAllHandlerRequest(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetAllRequest, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<IEnumerable<Category>> Handle(CategoryGetAllRequest request, CancellationToken cancellationToken)
        {
            var dbDataList = await _categoryRepository.GetAllAsync(x => x.DeletedBy == null);
            return [..dbDataList];
        }
    }
}

using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Queries.CategoryGetQuery
{
    internal class CategoryGetHandlerRequest(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetRequest, CategoryGetDto>
    {
        private readonly ICategoryRepository _categoryRepository= categoryRepository;

        public async Task<CategoryGetDto> Handle(CategoryGetRequest request, CancellationToken cancellationToken)
        {
            var query = (from current in await _categoryRepository.GetAllAsync(x => x.Id == request.Id && x.DeletedBy==null)
                         join parent in await _categoryRepository.GetAllAsync(x => x.DeletedBy == null) on current.ParentId equals parent.Id
                         into lj
                         from leftJoin in lj.DefaultIfEmpty()
                         select new CategoryGetDto
                         {
                             Name = current.Name,
                             ImageUrl = current.ImageUrl,
                             ParentName = leftJoin.Name,
                             CreatedAt = current.CreatedAt,
                             CreatedBy = current.CreatedBy,
                             UpdatedAt = current.UpdatedAt,
                             UpdatedBy = current.UpdatedBy,
                         });
            return await query.FirstOrDefaultAsync();
        }
    }
}

using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Queries.CategoryGetQuery
{
    public class CategoryGetRequest:IRequest<CategoryGetDto>
    {
        public int Id { get; set; }
    }
}

using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Commands.CategoryDeleteCommand
{
    public class CategoryDeleteRequest:IRequest<IEnumerable<Category>>
    {
        public int Id { get; set; }
    }
}

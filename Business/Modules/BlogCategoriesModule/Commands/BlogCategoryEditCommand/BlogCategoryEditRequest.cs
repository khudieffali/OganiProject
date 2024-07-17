using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Commands.BlogCategoryEditCommand
{
    public class BlogCategoryEditRequest:IRequest<BlogCategory>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

}

using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Commands.BlogCategoryAddCommand
{
    public class BlogCategoryAddRequest:IRequest<BlogCategory>
    {
        public required string Name { get; set; }
    }
}

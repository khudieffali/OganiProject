using Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Commands.BlogDeleteCommand
{
    public class BlogDeleteRequest:IRequest<IEnumerable<BlogGetAllDto>>
    {
        public int Id { get; set; }
    }
}

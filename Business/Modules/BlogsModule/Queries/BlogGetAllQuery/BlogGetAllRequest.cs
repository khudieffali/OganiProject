using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Queries.BlogGetAllQuery
{
    public class BlogGetAllRequest:IRequest<IEnumerable<BlogGetAllDto>>
    {
    }
}

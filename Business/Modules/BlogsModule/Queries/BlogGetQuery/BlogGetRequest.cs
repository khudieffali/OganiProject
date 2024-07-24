using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Queries.BlogGetQuery
{
    public class BlogGetRequest:IRequest<BlogGetDto>
    {
        public int Id { get; set; }
    }
}

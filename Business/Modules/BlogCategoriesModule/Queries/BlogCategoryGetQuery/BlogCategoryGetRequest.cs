using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Queries.BlogCategoryGetQuery
{
    public class BlogCategoryGetRequest:IRequest<BlogCategory>
    {
        public int Id { get; set; }
    }
}

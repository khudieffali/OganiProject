using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Queries.TagGetQuery
{
    public class TagGetRequest:IRequest<Tag>
    {
        public int Id { get; set; }
    }
}

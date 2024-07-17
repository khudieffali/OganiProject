using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Commands.TagEditCommand
{
    public class TagEditRequest:IRequest<Tag>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}

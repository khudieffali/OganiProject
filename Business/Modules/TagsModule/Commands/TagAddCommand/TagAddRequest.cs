using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Commands.TagAddCommand
{
    public class TagAddRequest:IRequest<Tag>
    {
        public required string Name { get; set; }
    }
}

using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Commands.SizeEditCommand
{
    public class SizeEditRequest:IRequest<Size>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}

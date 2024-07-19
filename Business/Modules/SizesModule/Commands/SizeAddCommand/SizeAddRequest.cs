using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Commands.SizeAddCommand
{
    public class SizeAddRequest:IRequest<Size>
    {
        public required string Name { get; set; }
    }
}

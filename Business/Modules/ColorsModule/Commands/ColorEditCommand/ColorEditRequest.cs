using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Commands.ColorEditCommand
{
    public class ColorEditRequest:IRequest<Color>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string HexCode { get; set; }
    }
}

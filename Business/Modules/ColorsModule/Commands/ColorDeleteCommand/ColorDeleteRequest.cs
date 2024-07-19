using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Commands.ColorDeleteCommand
{
    public class ColorDeleteRequest:IRequest<IEnumerable<Color>>
    {
        public int Id { get; set; }
    }
}

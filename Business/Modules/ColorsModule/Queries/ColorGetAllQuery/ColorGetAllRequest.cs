using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest:IRequest<IEnumerable<Color>>
    {
    }
}

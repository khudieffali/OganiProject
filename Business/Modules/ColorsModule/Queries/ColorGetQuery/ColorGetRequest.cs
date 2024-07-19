using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Queries.ColorGetQuery
{
    public class ColorGetRequest:IRequest<Color>
    {
        public int Id { get; set; }
    }
}

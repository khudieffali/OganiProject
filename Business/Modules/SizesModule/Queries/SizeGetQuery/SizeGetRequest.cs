using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Queries.SizeGetQuery
{
    public class SizeGetRequest:IRequest<Size>
    {
        public int Id { get; set; }
    }
}

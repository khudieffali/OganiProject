using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Queries.OrganicGetQuery
{
    public class OrganicGetRequest:IRequest<Organic>
    {
        public int Id { get; set; }
    }
}

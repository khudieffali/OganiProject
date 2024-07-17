using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Commands.OrganicDeleteCommand
{
    public class OrganicDeleteRequest:IRequest<IEnumerable<Organic>>    
    {
        public int Id { get; set; }
    }
}

using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Queries.OrganicGetQuery
{
    internal class OrganciGetHandlerRequest(IOrganicRepository organicRepository) : IRequestHandler<OrganicGetRequest, Organic>
    {
        private readonly IOrganicRepository _organicRepository = organicRepository;

        public async Task<Organic> Handle(OrganicGetRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _organicRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            return dbData;
        }
    }
}

using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Queries.OrganicGetAllQuery
{
    internal class OrganicGetAllHandlerRequest(IOrganicRepository organicRepository) : IRequestHandler<OrganicGetAllRequest, IEnumerable<Organic>>
    {
        private readonly IOrganicRepository _organicRepository = organicRepository;

        public async Task<IEnumerable<Organic>> Handle(OrganicGetAllRequest request, CancellationToken cancellationToken)
        {
            var dbDataList =await _organicRepository.GetAllAsync(x => x.DeletedAt == null);
            return [..dbDataList];
        }
    }
}

using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Queries.SizeGetAllQuery
{
    internal class SizeGetAllHandlerRequest(ISizeRepository sizeRepository) : IRequestHandler<SizeGetAllRequest, IEnumerable<Size>>
    {
        private readonly ISizeRepository _sizeRepository = sizeRepository;

        public async Task<IEnumerable<Size>> Handle(SizeGetAllRequest request, CancellationToken cancellationToken)
        {
            var dbDataList = await _sizeRepository.GetAllAsync(x => x.DeletedBy == null);
            return [..dbDataList];
        }
    }
}

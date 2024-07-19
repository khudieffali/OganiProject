using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Commands.SizeDeleteCommand
{
    internal class SizeDeleteHandlerRequest(ISizeRepository sizeRepository) : IRequestHandler<SizeDeleteRequest, IEnumerable<Size>>
    {
        private readonly ISizeRepository _sizeRepository = sizeRepository;

        public async Task<IEnumerable<Size>> Handle(SizeDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _sizeRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            await _sizeRepository.Delete(dbData);
            var dbDataList = await _sizeRepository.GetAllAsync(x => x.DeletedBy == null);
            return [.. dbDataList];
        }
    }
}

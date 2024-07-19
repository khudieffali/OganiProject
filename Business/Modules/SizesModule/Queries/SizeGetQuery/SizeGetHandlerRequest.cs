using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Queries.SizeGetQuery
{
    internal class SizeGetHandlerRequest(ISizeRepository sizeRepository) : IRequestHandler<SizeGetRequest, Size>
    {
        private readonly ISizeRepository _sizeRepository = sizeRepository;

        public async Task<Size> Handle(SizeGetRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _sizeRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            return dbData;
        }
    }
}

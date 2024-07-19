using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Commands.SizeAddCommand
{
    internal class SizeAddHandlerRequest(ISizeRepository sizeRepository) : IRequestHandler<SizeAddRequest, Size>
    {
        private readonly ISizeRepository _sizeRepository = sizeRepository;

        public async Task<Size> Handle(SizeAddRequest request, CancellationToken cancellationToken)
        {
           var newData= new Size { Name = request.Name };
            await _sizeRepository.Add(newData);
            return newData;
        }
    }
}

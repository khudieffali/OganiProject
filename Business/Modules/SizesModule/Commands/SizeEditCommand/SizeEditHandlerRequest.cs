using Infrastructure.Entities;
using Infrastructure.Extensions;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.SizesModule.Commands.SizeEditCommand
{
    internal class SizeEditHandlerRequest(ISizeRepository sizeRepository) : IRequestHandler<SizeEditRequest, Size>
    {
        private readonly ISizeRepository _sizeRepository = sizeRepository;

        public async Task<Size> Handle(SizeEditRequest request, CancellationToken cancellationToken)
        {
            var updateData= new Size { Id = request.Id,Name=request.Name,Slug=request.Name.ToSlug() };
            await _sizeRepository.Update(updateData);
            return updateData;
        }
    }
}

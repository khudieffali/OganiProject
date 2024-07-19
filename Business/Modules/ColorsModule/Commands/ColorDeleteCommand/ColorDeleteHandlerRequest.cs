using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Commands.ColorDeleteCommand
{
    internal class ColorDeleteHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorDeleteRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<IEnumerable<Color>> Handle(ColorDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _colorRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            await _colorRepository.Delete(dbData);
            var dbDataList = await _colorRepository.GetAllAsync(x => x.DeletedBy == null);
            return dbDataList;
        }
    }
}

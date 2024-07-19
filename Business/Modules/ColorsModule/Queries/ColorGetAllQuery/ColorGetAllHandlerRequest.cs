using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    internal class ColorGetAllHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<IEnumerable<Color>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var dbDataList = await _colorRepository.GetAllAsync(x => x.DeletedBy == null);
            return [..dbDataList];
        }
    }
}

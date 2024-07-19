using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Queries.ColorGetQuery
{
    internal class ColorGetHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorGetRequest, Color>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<Color> Handle(ColorGetRequest request, CancellationToken cancellationToken)
        {
            var dbData=await _colorRepository.GetAsync(x=>x.Id==request.Id && x.DeletedBy==null);
            return dbData;
        }
    }
}

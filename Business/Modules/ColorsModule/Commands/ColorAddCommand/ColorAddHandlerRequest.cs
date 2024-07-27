using Infrastructure.Entities;
using Infrastructure.Extensions;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Commands.ColorAddCommand
{
    internal class ColorAddHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            var newData= new Color { Name=request.Name,HexCode = request.HexCode,Slug=request.Name.ToSlug() };
            await _colorRepository.Add(newData);
            return newData;
        }
    }
}

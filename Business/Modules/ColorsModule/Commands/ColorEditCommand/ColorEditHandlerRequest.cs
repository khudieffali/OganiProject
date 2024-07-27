using Infrastructure.Entities;
using Infrastructure.Extensions;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ColorsModule.Commands.ColorEditCommand
{
    internal class ColorEditHandlerRequest(IColorRepository colorRepository) : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository _colorRepository = colorRepository;

        public async Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            var dbDataEdit = new Color { Id = request.Id, Name = request.Name, HexCode = request.HexCode,Slug=request.Name.ToSlug() };
            await _colorRepository.Update(dbDataEdit);
            return dbDataEdit;
        }
    }
}

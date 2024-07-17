using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Commands.OrganicEditCommand
{
    internal class OrganicEditHandlerRequest(IFileService fileService, IOrganicRepository organicRepository) : IRequestHandler<OrganicEditRequest, Organic>
    {
        private readonly IFileService _fileService = fileService;
        private readonly IOrganicRepository _organicRepository=organicRepository;

        public async Task<Organic> Handle(OrganicEditRequest request, CancellationToken cancellationToken)
        {
            var oldOrganic = await _organicRepository.GetAsync(x => x.Id == request.Id);
            oldOrganic.Title= request.Title;
            oldOrganic.SubTitle= request.SubTitle;
            oldOrganic.Description= request.Description;
            oldOrganic.ImageUrl = await _fileService.UpdateFileChangeAsync(request.ImageUrl,oldOrganic.ImageUrl,true);
            oldOrganic.IsMain= request.IsMain;  
            await _organicRepository.SaveAsync();
            return oldOrganic;
        }
    }
}

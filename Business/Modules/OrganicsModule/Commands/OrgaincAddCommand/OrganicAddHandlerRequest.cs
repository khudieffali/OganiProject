using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Commands.OrgaincAddCommand
{
    internal class OrganicAddHandlerRequest(IOrganicRepository organicRepository, IFileService fileService) : IRequestHandler<OrganicAddRequest, Organic>
    {
        private readonly IOrganicRepository _organicRepository = organicRepository;
        private readonly IFileService _fileService=fileService; 

        public async Task<Organic> Handle(OrganicAddRequest request, CancellationToken cancellationToken)
        {
            var fileName =await _fileService.UploadFileAsync(request.ImageUrl);
            var newOrganic= new Organic {
                ImageUrl = fileName,
                Title=request.Title,
                SubTitle=request.SubTitle,
                Description=request.Description,
                IsMain=request.IsMain 
            };
            await _organicRepository.Add(newOrganic);
            return newOrganic;
        }
    }
}

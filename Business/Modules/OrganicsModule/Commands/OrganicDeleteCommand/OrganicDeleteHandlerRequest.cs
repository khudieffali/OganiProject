using Infrastructure.Commons.Abstracts;
using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Commands.OrganicDeleteCommand
{
    internal class OrganicDeleteHandlerRequest(IOrganicRepository organicRepository, IFileService fileService) : IRequestHandler<OrganicDeleteRequest, IEnumerable<Organic>>
    {
        private readonly IOrganicRepository _organicRepository = organicRepository;
        private readonly IFileService _fileService=fileService;
        public async Task<IEnumerable<Organic>> Handle(OrganicDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _organicRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            dbData.ImageUrl = await _fileService.DeleteFileChangeAsync(null, dbData.ImageUrl,false);
            await _organicRepository.Delete(dbData);
            var dbOrganicList = await _organicRepository.GetAllAsync(x => x.DeletedBy == null);
            return [..dbOrganicList];
        }
    }
}

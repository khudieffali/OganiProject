using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Commands.TagEditCommand
{
    internal class TagEditHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagEditRequest, Tag>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<Tag> Handle(TagEditRequest request, CancellationToken cancellationToken)
        {
            var dbDataEdit= new Tag { Id=request.Id, Name = request.Name };
            await _tagRepository.Update(dbDataEdit);
            return dbDataEdit;
        } 
    }
}

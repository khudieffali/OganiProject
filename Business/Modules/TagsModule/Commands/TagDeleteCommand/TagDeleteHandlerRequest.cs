using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Commands.TagDeleteCommand
{
    internal class TagDeleteHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagDeleteRequest, IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<IEnumerable<Tag>> Handle(TagDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _tagRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            await _tagRepository.Delete(dbData);
            var dbDataList = await _tagRepository.GetAllAsync(x => x.DeletedBy == null);
            return [..dbDataList];
        }
    }
}

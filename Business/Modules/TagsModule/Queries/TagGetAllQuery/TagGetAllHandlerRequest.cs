using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Queries.TagGetAllQuery
{
    internal class TagGetAllHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagGetAllRequest, IEnumerable<Tag>>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<IEnumerable<Tag>> Handle(TagGetAllRequest request, CancellationToken cancellationToken)
        {
            var dbDataList = await _tagRepository.GetAllAsync(x => x.DeletedBy == null);
            return [..dbDataList];
        }
    }
}

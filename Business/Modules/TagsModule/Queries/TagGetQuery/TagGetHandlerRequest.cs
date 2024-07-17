using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Queries.TagGetQuery
{
    internal class TagGetHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagGetRequest, Tag>
    {
        private readonly ITagRepository _tagRepository = tagRepository;

        public async Task<Tag> Handle(TagGetRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _tagRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            return dbData;
        }
    }
}

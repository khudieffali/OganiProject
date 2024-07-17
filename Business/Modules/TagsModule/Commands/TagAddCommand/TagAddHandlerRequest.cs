using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Commands.TagAddCommand
{
	internal class TagAddHandlerRequest(ITagRepository tagRepository) : IRequestHandler<TagAddRequest, Tag>
	{
		private readonly ITagRepository _tagRepository = tagRepository;

		public async Task<Tag> Handle(TagAddRequest request, CancellationToken cancellationToken)
		{
			var newData= new Tag { Name = request.Name};
		    await _tagRepository.Add(newData);
			return newData;
		}
	}
}

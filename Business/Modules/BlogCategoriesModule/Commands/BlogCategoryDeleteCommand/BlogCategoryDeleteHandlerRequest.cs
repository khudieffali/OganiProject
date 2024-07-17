using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Commands.BlogCategoryDeleteCommand
{
	internal class BlogCategoryDeleteHandlerRequest(IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogCategoryDeleteRequest, IEnumerable<BlogCategory>>
	{
		private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

		public async Task<IEnumerable<BlogCategory>> Handle(BlogCategoryDeleteRequest request, CancellationToken cancellationToken)
		{
			var dbData = await _blogCategoryRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
			await _blogCategoryRepository.Delete(dbData);
			var dbDataList= await _blogCategoryRepository.GetAllAsync(x=>x.DeletedBy== null);
			return [.. dbDataList];
		}
	}
}

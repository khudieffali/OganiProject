using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Queries.BlogCategoryGetAllQuery
{
	internal class BlogCategoryGetAllHandlerRequest(IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogCategoryGetAllRequest, IEnumerable<BlogCategory>>
	{
		private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

		public async Task<IEnumerable<BlogCategory>> Handle(BlogCategoryGetAllRequest request, CancellationToken cancellationToken)
		{
			var dbDataList = await _blogCategoryRepository.GetAllAsync(x => x.DeletedBy == null);
			return [..dbDataList];
		}
	}
}

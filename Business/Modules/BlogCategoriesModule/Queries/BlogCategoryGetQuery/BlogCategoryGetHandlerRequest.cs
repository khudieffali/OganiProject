using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Queries.BlogCategoryGetQuery
{
	internal class BlogCategoryGetHandlerRequest(IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogCategoryGetRequest, BlogCategory>
	{
		private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

		public async Task<BlogCategory> Handle(BlogCategoryGetRequest request, CancellationToken cancellationToken)
		{
			var dbData = await _blogCategoryRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
			return dbData;
		}
	}
}

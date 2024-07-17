using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Commands.BlogCategoryAddCommand
{
	internal class BlogCategoryAddHandlerRequest(IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogCategoryAddRequest, BlogCategory>
	{
		private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

		public async Task<BlogCategory> Handle(BlogCategoryAddRequest request, CancellationToken cancellationToken)
		{
			var newData= new BlogCategory { Name = request.Name };
			await _blogCategoryRepository.Add(newData);
			return newData;
		}
	}
}

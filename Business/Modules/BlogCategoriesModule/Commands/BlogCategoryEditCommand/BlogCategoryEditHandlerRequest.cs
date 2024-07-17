using Infrastructure.Entities;
using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogCategoryModule.Commands.BlogCategoryEditCommand
{
	internal class BlogCategoryEditHandlerRequest(IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogCategoryEditRequest, BlogCategory>
	{
		private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;

		public async Task<BlogCategory> Handle(BlogCategoryEditRequest request, CancellationToken cancellationToken)
		{
			var dbDataEdit= new BlogCategory { Id= request.Id, Name=request.Name};
			await _blogCategoryRepository.Update(dbDataEdit);
			return dbDataEdit;
		}
	}
}

using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Queries.BlogGetAllQuery
{
    internal class BlogGetAllHandlerRequest(IBlogRepository blogRepository, IBlogCategoryRepository blogCategoryRepository) : IRequestHandler<BlogGetAllRequest, IEnumerable<BlogGetAllDto>>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;



        public async Task<IEnumerable<BlogGetAllDto>> Handle(BlogGetAllRequest request, CancellationToken cancellationToken)
        {

            var dbDataList = (from bl in await _blogRepository.GetAllAsync(x => x.DeletedBy == null)
                              join blogCt in await _blogCategoryRepository.GetAllAsync() on bl.BlogCategoryId equals blogCt.Id
                              select new BlogGetAllDto
                              {
                                  Id = bl.Id,
                                  Title = bl.Title,
                                  ImageUrl = bl.ImageUrl,
                                  Description = bl.Description,
                                  BlogCategoryName = blogCt.Name,
                                  BlogCategoryId = blogCt.Id,

                              });
            return [.. dbDataList];
        }
    }
}

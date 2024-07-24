using Infrastructure.Repositroies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Queries.BlogGetQuery
{
    internal class BlogGetHandlerRequest(IBlogRepository blogRepository, IBlogCategoryRepository blogCategoryRepository, ITagRepository tagRepository) : IRequestHandler<BlogGetRequest, BlogGetDto>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;
        private readonly ITagRepository _tagRepository = tagRepository;
        public async Task<BlogGetDto> Handle(BlogGetRequest request, CancellationToken cancellationToken)
        {
            var blogList =await _blogRepository.GetAllAsync(x => x.DeletedBy == null & x.Id==request.Id);
            var tags = await _tagRepository.GetAllAsync();
            var blogCategoryList= await _blogCategoryRepository.GetAllAsync();
            var dbData = (from bl in blogList
                          join blogCt in blogCategoryList on bl.BlogCategoryId equals blogCt.Id
                          select new BlogGetDto
                          {
                              Id = bl.Id,
                              Title = bl.Title,
                              Description = bl.Description,
                              ImageUrl = bl.ImageUrl,
                              BlogCategoryName = blogCt.Name,
                              BlogCategoryId = blogCt.Id,
                              BlogTagId= (from bt in bl.BlogTagsList
                                          join tg in tags on bt.TagId equals tg.Id
                                          select tg.Id).ToList(),
                              BlogTagName = (from bt in bl.BlogTagsList
                                            join tg in tags on bt.TagId equals tg.Id
                                            select tg.Name).ToList(),
                              CreatedAt = bl.CreatedAt,
                              CreatedBy = bl.CreatedBy,
                              UpdatedAt = bl.UpdatedAt,
                              UpdatedBy = bl.UpdatedBy,
                          }); ;
            return dbData.FirstOrDefault();
        }
    }
}

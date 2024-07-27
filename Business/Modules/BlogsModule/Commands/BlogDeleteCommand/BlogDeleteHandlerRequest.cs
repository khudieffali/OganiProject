using Business.Modules.BlogsModule.Commands.BlogEditCommand;
using Business.Modules.BlogsModule.Queries.BlogGetAllQuery;
using Business.Modules.BlogsModule.Queries.BlogGetQuery;
using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Commands.BlogDeleteCommand
{
    internal class BlogDeleteHandlerRequest(IBlogRepository blogRepository, IFileService fileService, IBlogCategoryRepository blogCategoryRepository, ITagRepository tagRepository, IBlogToTagRepository blogToTagRepository) : IRequestHandler<BlogDeleteRequest, IEnumerable<BlogGetAllDto>>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IFileService _fileService = fileService;
        private readonly IBlogCategoryRepository _blogCategoryRepository = blogCategoryRepository;
        private readonly IBlogToTagRepository _blogToTagRepository=blogToTagRepository;
        public async Task<IEnumerable<BlogGetAllDto>> Handle(BlogDeleteRequest request, CancellationToken cancellationToken)
        {
            var dbData = await _blogRepository.GetAsync(x => x.Id == request.Id && x.DeletedBy == null);
            dbData.ImageUrl = await _fileService.DeleteFileChangeAsync(null, dbData.ImageUrl);
            await _blogRepository.Delete(dbData);
            var dbDataList = (from bl in await _blogRepository.GetAllAsync(x => x.DeletedBy == null)
                              join blogCt in await _blogCategoryRepository.GetAllAsync() on bl.BlogCategoryId equals blogCt.Id
                              select new BlogGetAllDto
                              {
                                  Id = bl.Id,
                                  Title = bl.Title,
                                  ImageUrl = bl.ImageUrl,
                                  Description = bl.Description,
                                  BlogCategoryId = blogCt.Id,
                                  BlogCategoryName = blogCt.Name,
                              });
            return [.. dbDataList];
        }
    }
}

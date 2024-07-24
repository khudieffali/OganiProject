using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using MediatR.NotificationPublishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Commands.BlogAddCommand
{
    internal class BlogAddHandlerRequest(IBlogRepository blogRepository, IFileService fileService) : IRequestHandler<BlogAddRequest, Blog>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IFileService _fileService=fileService;
        public async Task<Blog> Handle(BlogAddRequest request, CancellationToken cancellationToken)
        {
            var newData = new Blog
            {
                Title = request.Title,
                Description = request.Description,
                ImageUrl = await _fileService.UploadFileAsync(request.ImageUrl),
                BlogCategoryId = request.BlogCategoryId,
                BlogTagsList = []
            };
            if(request.TagIds is { })
            {
                foreach (var item in request.TagIds)
                {
                    newData.BlogTagsList.Add(new BlogToTag() { TagId = item, BlogId = newData.Id });
                }
            }
           
            await _blogRepository.Add(newData);
            return newData;
        }
    }
}

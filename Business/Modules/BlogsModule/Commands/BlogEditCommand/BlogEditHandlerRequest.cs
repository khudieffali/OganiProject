using Business.Modules.BlogsModule.Commands.BlogAddCommand;
using Business.Modules.BlogsModule.Queries.BlogGetQuery;
using Infrastructure.Entities;
using Infrastructure.Extensions;
using Infrastructure.Repositroies;
using Infrastructure.Services.Abstarcts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Commands.BlogEditCommand
{
    internal class BlogEditHandlerRequest(IBlogRepository blogRepository, IFileService fileService, ITagRepository tagRepository, IBlogCategoryRepository blogCategoryRepository, IBlogToTagRepository blogToTagRepository) : IRequestHandler<BlogEditRequest, Blog>
    {
        private readonly IBlogRepository _blogRepository = blogRepository;
        private readonly IFileService _fileService = fileService;
        private readonly IBlogToTagRepository _blogToTagRepository=blogToTagRepository;
        public async Task<Blog> Handle(BlogEditRequest request, CancellationToken cancellationToken)
        {

            var dbData= await _blogRepository.GetAsync(x=>x.Id==request.Id && x.DeletedBy==null);
            if(dbData!=null)
            {
                dbData.Title=request.Title;
                dbData.Slug = request.Title.ToSlug();
                dbData.Description=request.Description;
                dbData.ImageUrl = request.ImageUrl is null ? dbData.ImageUrl : await _fileService.UpdateFileChangeAsync(request.ImageUrl, dbData.ImageUrl, true);
                dbData.BlogCategoryId=request.BlogCategoryId;
                var existingTags =await _blogToTagRepository.GetAllAsync(x => x.BlogId == request.Id && x.DeletedBy==null);
                await _blogToTagRepository.DeleteRange([.. existingTags]);
                if (request.TagIds != null && request.TagIds.Count > 0)
                {
                    foreach (var tagId in request.TagIds)
                    {
                       await _blogToTagRepository.Add(new BlogToTag { BlogId = dbData.Id, TagId = tagId });
                    }
                }
                await _blogRepository.SaveAsync();
            }
               return dbData;
        }
    }
}

using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Commands.BlogEditCommand
{
    public class BlogEditRequest:IRequest<Blog>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public  IFormFile? ImageUrl { get; set; }
        public string? Description { get; set; }
        public int BlogCategoryId { get; set; }
        public List<int>? TagIds { get; set; }
    }
}

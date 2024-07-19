using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    public class CategoryEditRequest:IRequest<Category>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public int? ParentId { get; set; }
    }
}

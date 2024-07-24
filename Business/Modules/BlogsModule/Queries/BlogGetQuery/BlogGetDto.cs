using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Queries.BlogGetQuery
{
    public class BlogGetDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public string? Description { get; set; }
        public int BlogCategoryId { get; set; }
        public required string BlogCategoryName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<int>? BlogTagId { get; set; }
        public List<string>?  BlogTagName { get; set; }

    }
}

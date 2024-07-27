using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Blog:BaseEntity<int>
    {
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public string? Description { get; set; }
        public required string Slug { get; set; }
        public int BlogCategoryId { get; set; }
        public BlogCategory? BlogCategory { get; set; }
        public List<BlogToTag>? BlogTagsList { get; set; }
    }
}

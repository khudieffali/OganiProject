using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.BlogsModule.Queries.BlogGetAllQuery
{
    public class BlogGetAllDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string ImageUrl { get; set; }
        public string? Description { get; set; }
        public int BlogCategoryId { get; set; }
        public required string BlogCategoryName { get; set; }
    }
}

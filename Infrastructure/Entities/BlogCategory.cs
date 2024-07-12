using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BlogCategory:BaseEntity<int>
    {
        public required string Name { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}

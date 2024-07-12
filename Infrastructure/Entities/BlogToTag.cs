using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class BlogToTag:BaseEntity<int>  
    {
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
    }
}

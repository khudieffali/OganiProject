using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Comment:BaseEntity<int>
    {
        public string? Description { get; set; }
        public int Count { get; set; }
    }
}

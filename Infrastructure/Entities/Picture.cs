using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Picture:BaseEntity<int>
    {
        public string? ImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}

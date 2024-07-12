using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Organic:BaseEntity<int>
    {
        public required string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public required string ImageUrl { get; set; }
    }
}

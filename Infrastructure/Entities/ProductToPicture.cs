using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class ProductToPicture:BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int PictureId { get; set; }
        public Picture? Picture { get; set; }
    }
}

using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class Product:BaseEntity<int>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int Review { get; set; }
        public bool IsAvailability { get; set; }
        public double? Weight { get; set; }
        public string? Shipping { get; set; }
        public double? Rating { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public required List<Picture> ProductPictures { get; set; }
        public List<ProductToColor>? ProductToColors { get; set; }
        public List<ProductToSize>? ProductToSizes { get; set; }
    }
}

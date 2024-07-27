using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    public class ProductGetAllDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool IsAvailability { get; set; }
        public string? Weight { get; set; }
        public string? Shipping { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public int MainPhotoId { get; set; }
        public required string MainPhoto { get; set; }
    }
}

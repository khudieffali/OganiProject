﻿using Infrastructure.Commons.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure.Entities
{
    public class ProductToSize : BaseEntity<int>
    {
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int SizeId { get; set; }
        public Size? Size { get; set; }
    }
}

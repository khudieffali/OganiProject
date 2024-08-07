﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Queries.ProductGetQuery
{
    public class ProductGetRequest:IRequest<ProductGetDto>
    {
        public int Id { get; set; }
    }
}

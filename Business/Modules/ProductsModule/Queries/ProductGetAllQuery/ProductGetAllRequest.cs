﻿using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Queries.ProductGetAllQuery
{
    public class ProductGetAllRequest:IRequest<IEnumerable<ProductGetAllDto>>
    {
    }
}

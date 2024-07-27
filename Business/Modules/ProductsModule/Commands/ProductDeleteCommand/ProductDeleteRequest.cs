using Business.Modules.ProductsModule.Queries.ProductGetAllQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Commands.ProductDeleteCommand
{
    public class ProductDeleteRequest:IRequest<IEnumerable<ProductGetAllDto>>
    {
        public int Id { get; set; }
    }
}

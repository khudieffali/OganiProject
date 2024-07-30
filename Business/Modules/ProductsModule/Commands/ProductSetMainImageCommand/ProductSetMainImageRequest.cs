using Business.Modules.ProductsModule.Queries.ProductGetQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.ProductsModule.Commands.ProductSetMainImageCommand
{
    public class ProductSetMainImageRequest:IRequest<ProductGetDto>
    {
        public int Id { get; set; }
        public int MainPhotoId { get; set; }
    }
}

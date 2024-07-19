using Infrastructure.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.OrganicsModule.Commands.OrganicEditCommand
{
    public class OrganicEditRequest:IRequest<Organic>
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public bool IsMain { get; set; }
    }
}

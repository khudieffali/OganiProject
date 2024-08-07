﻿using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Commands.TagDeleteCommand
{
    public class TagDeleteRequest:IRequest<IEnumerable<Tag>>
    {
        public int Id { get; set; }
    }
}

﻿using Infrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Modules.TagsModule.Queries.TagGetAllQuery
{
    public class TagGetAllRequest:IRequest<IEnumerable<Tag>>
    {
    }
}
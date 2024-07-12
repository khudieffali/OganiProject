﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Abstracts
{
    internal interface IAuditableEntity
    {
        int CreatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        int? UpdatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
        int? DeletedBy { get; set; }  
        DateTime? DeletedAt { get; set; }


    }
}

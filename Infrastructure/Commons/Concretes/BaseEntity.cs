﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Concretes
{
    public class BaseEntity<TKey>:AuditableEntity where TKey : struct
    {
        public TKey Id { get; set; }
    }
}

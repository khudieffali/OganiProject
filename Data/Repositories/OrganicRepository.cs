﻿using Infrastructure.Commons.Concretes;
using Infrastructure.Entities;
using Infrastructure.Repositroies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class OrganicRepository(DbContext context) : Repository<Organic>(context), IOrganicRepository
    {
    }
}
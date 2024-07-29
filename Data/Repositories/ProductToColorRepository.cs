using Data.DataContexts;
using Infrastructure.Commons.Concretes;
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
    public class ProductToColorRepository(DbContext context, OganiDataContext db) : Repository<ProductToColor>(context), IProductToColorRepository
    {
        private readonly OganiDataContext _db = db;
        public async Task DeleteRange(List<ProductToColor> colors)
        {
            _db.RemoveRange(colors);
            await _db.SaveChangesAsync();
        }
    }
}

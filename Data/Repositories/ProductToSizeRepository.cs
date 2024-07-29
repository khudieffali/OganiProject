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
    public class ProductToSizeRepository(DbContext context, OganiDataContext db) : Repository<ProductToSize>(context), IProductToSizeRepository
    {
        private readonly OganiDataContext _db = db;
        public async Task DeleteRange(List<ProductToSize> sizes)
        {
            _db.RemoveRange(sizes);
            await _db.SaveChangesAsync();
        }
    }
}

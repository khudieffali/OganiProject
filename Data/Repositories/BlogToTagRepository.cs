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
    public class BlogToTagRepository(DbContext context, OganiDataContext db) : Repository<BlogToTag>(context), IBlogToTagRepository
    {
        private readonly OganiDataContext _db=db;


        public async Task DeleteRange(List<BlogToTag> tags)
        {
             _db.RemoveRange(tags);
            await _db.SaveChangesAsync();
        }
    }
}

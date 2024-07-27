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
    public class PictureRepository(DbContext context,OganiDataContext db) : Repository<Picture>(context), IPictureRepository
    {
       
        private readonly OganiDataContext _db=db;

        public async Task DeleteRange(List<Picture> pictureList)
        {
           _db.RemoveRange(pictureList);
           await _db.SaveChangesAsync();   
        }
    }
}

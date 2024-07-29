using Infrastructure.Commons.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commons.Concretes
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _table;
        protected Repository(DbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _table.AddAsync(entity);
            await SaveAsync();
            return entity;
        }
        public async Task<T> Update(T entity)
        {
            _table.Entry(entity).State = EntityState.Modified;
            await SaveAsync();
            return entity;
        }
        public async Task Delete(T entity)
        {
          _table.Remove(entity);
          await SaveAsync();
        }
        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
          var query= _table.AsQueryable();
            if (true)
            {
                query=query.AsNoTracking();
            }
            if(predicate != null)
            {
                query=query.Where(predicate);
            }
            return query;   
        }

        public async Task<T> GetAsync(Expression<Func<T,bool>>? predicate = null)
        {
           if(predicate == null)
            {
                return await _table.FirstOrDefaultAsync();
            }
            var data = await _table.FirstOrDefaultAsync(predicate);
            return data;
            }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

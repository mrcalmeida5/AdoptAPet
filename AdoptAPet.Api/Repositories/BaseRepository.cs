using AdoptAPet.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdoptAPet.Api.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            var entity = await _context.FindAsync<T>(entityId);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .AsNoTracking<T>()
                .ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> includes)
        {
            return await _context.Set<T>()
                .AsNoTracking<T>()
                .Include(includes)
                .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int entityId)
        {
            return await _context.FindAsync<T>(entityId);
        }

        public async Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includes)
        {
            return await _context.Set<T>()
                .AsNoTracking()
                .Include(includes)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

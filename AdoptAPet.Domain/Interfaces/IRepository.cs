using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdoptAPet.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, object>> includes);
        Task<T> GetByIdAsync(int entityId);
        Task<T> GetByPredicateAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> includes);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int entityId);
    }
}

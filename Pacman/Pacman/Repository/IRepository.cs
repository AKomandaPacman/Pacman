using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pacman.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task RemoveAsync(int id);
        Task<int> SaveChangesAsync();
        Task<List<T>> QueryByPredicateAsync<T>(Expression<Func<T, bool>> predicate) where T : class, TEntity;
    }
}

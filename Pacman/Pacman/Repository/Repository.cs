using Microsoft.EntityFrameworkCore;
using Pacman.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Pacman.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly PacmanContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(PacmanContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            obj.LastUpdated = DateTime.UtcNow;
            await DbSet.AddAsync(obj);
            await SaveChangesAsync();
            return obj;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await Task.FromResult(DbSet.AsNoTracking().SingleOrDefault(x => x.Id == id));
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(DbSet.ToList());
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            obj.LastUpdated = DateTime.UtcNow;
            DbSet.Update(obj);
            await SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(int id)
        {
            DbSet.Remove(await DbSet.FindAsync(id));
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<List<T>> QueryByPredicateAsync<T>(Expression<Func<T, bool>> predicate) where T : class, TEntity
        {
            return await Task.Run(() => Db.Set<T>().Where(predicate).ToList());
        }

    }
}

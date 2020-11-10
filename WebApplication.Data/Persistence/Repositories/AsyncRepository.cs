using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Persistence.Repositories
{
    public class AsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public AsyncRepository(DbContext context)
        {
            Context = context;
        }

        public ValueTask<TEntity> GetAsync(params Guid[] guids)
        {
            return Context.Set<TEntity>().FindAsync(guids);
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            return Context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return Context.Set<TEntity>().AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            return Context.Set<TEntity>().AddRangeAsync(entities);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace WebApplication.Data.Core.Repositories
{
    /// <summary>
    /// Generic AsyncRepository Interface for my data access layer
    ///
    /// See AsyncRepository Pattern for more information.
    /// (Also See UnitOfWork Pattern for why there is no UPDATE functions here)
    /// </summary>
    /// <typeparam name="TEntity">The entity class used when creating the repository interface</typeparam>
    public interface IAsyncRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetAsync(params Guid[] guids);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}

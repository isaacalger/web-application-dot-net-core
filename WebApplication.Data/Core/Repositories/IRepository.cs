using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Core.EntityModels;

namespace WebApplication.Data.Core.Repositories
{
    /// <summary>
    /// Generic Repository Interface for my data access layer
    ///
    /// See Repository Pattern for more information.
    /// (Also See UnitOfWork Pattern for why there is no UPDATE functions here)
    /// </summary>
    /// <typeparam name="TEntity">The entity class used when creating the repository interface</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}

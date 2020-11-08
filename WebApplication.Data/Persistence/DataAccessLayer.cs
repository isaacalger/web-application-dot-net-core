using System;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Core;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Persistence
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly WebApplicationDbContext _context;

        public DataAccessLayer(WebApplicationDbContext context)
        {
            _context = context;
        }

        public IUserAccountRepository Users { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        /// <summary>
        ///     <para>
        ///         Commits all changes made in this context to the database.
        ///     </para>
        /// </summary>
        /// <returns>
        ///     The number of state entries written to the database.
        /// </returns>
        /// <exception cref="DbUpdateException">
        ///     An error is encountered while saving to the database.
        /// </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///     A concurrency violation is encountered while saving to the database.
        ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
        ///     This is usually because the data in the database has been modified since it was loaded into memory.
        /// </exception>
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}

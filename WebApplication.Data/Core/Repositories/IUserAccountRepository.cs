using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebApplication.Data.Core.WebApplicationEntities;

namespace WebApplication.Data.Core.Repositories
{
    public interface IUserAccountRepository : IRepository<UserAccount>
    {
        // This will eventually make it up into the IRepository Interface but I wanted to bring something into this interface that I could extend upon.
        UserAccount FirstOrDefault(Expression<Func<UserAccount, bool>> predicate);
    }
}

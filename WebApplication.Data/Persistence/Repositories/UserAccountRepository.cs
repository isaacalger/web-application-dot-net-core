using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Persistence.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(DbContext context) : base(context)
        { }

        public UserAccount FirstOrDefault(Expression<Func<UserAccount, bool>> predicate)
        {
            return Context.Set<UserAccount>().SingleOrDefault(predicate);
        }
    }
}
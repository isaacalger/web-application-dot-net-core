using System;
using System.Linq;
using System.Linq.Expressions;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Persistence.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(WebApplicationDbContext context) : base(context)
        { }

        public UserAccount FirstOrDefault(Expression<Func<UserAccount, bool>> predicate)
        {
            return Context.Set<UserAccount>().SingleOrDefault(predicate);
        }
    }
}
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Persistence.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(WebApplicationDbContext context) : base(context)
        { }


    }
}
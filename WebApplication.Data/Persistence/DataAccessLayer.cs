using System;
using WebApplication.Data.Core;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Persistence
{
    public class DataAccessLayer : IDataAccessLayer
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IUserAccountRepository Users { get; }
        public int Complete()
        {
            throw new NotImplementedException();
        }
    }
}

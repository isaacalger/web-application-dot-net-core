using System;
using WebApplication.Data.Core.Repositories;

namespace WebApplication.Data.Core
{
    /// <summary>
    /// The IDataAccessLayer Can also be called the UnitOfAccess Layer.
    /// This Layer allows us to decouple what the Application needs from where it eventually gets it.
    ///
    /// HUGE HELP When Mocking!!!
    /// </summary>
    public interface IDataAccessLayer : IDisposable
    {
        IUserAccountRepository Users { get; }

        int Complete();
    }
}
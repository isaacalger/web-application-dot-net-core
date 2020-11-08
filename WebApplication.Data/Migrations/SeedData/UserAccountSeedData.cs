using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Data.Core.EntityModels;

namespace WebApplication.Data.Migrations.SeedData
{
    public class UserAccountSeedData
    {
        public IList<UserAccount> GetSeedUserAccounts()
        {
            return new List<UserAccount>()
            {
                new UserAccount
                {
                    Guid = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    Email = "IsaacAlger@gmail.com",
                    Username = "IsaacAlger",
                    PasswordHash = "TestHash"
                },
                new UserAccount
                {
                    Guid = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    Email = "IsaacAlger2@gmail.com",
                    Username = "IsaacAlger2",
                    PasswordHash = "TestHash2"
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Migrations.SeedData;

namespace WebApplication.Tests
{
    public static class TestData
    {
        public static List<UserAccount> GetUserAccounts()
        {
            return new UserAccountSeedData().GetSeedUserAccounts();
        }

    }
}

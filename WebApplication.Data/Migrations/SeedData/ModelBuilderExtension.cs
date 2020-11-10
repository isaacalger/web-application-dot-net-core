using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Core.EntityModels;

namespace WebApplication.Data.Migrations.SeedData
{
    public static class ModelBuilderExtensions
    {

        // Todo I need to add a Configure method to take in the configurations.

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedUsers();
        }

        private static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccountSeedData().GetSeedUserAccounts()
            );
        }
    }
}

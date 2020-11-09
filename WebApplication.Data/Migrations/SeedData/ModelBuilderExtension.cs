using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Core.EntityModels;

namespace WebApplication.Data.Migrations.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedUsers();
        }

        private static void SeedUsers(this ModelBuilder modelBuilder)
        {

            var test = new UserAccountSeedData();

            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccountSeedData().GetSeedUserAccounts()
            );
        }
    }
}

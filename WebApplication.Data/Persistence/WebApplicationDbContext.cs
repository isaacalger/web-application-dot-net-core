using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Core.EntityModels;
using WebApplication.Data.Migrations.SeedData;

namespace WebApplication.Data.Persistence
{
    /// <summary>
    /// PackageMangerConsole Commands
    /// Add-Migration "Migration Name" -DbContext WebApplicationDbContext
    /// Update-Database -DbContext WebApplicationDbContext
    ///
    /// dotnet tool install --global dotnet-ef
    /// </summary>
    public class WebApplicationDbContext : DbContext
    {
        public WebApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedData();
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }
    }
}

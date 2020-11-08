using System;
using System.ComponentModel.Design.Serialization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        //// TODO fix this so its reading from a configuration and not a string.
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebApplicationDb;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.SeedData();
        }

        public virtual DbSet<UserAccount> UserAccounts { get; set; }
    }
}

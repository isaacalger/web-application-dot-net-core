using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Data.Core.EntityModels;

namespace WebApplication.Data.Persistence.EntityConfiguration
{
    public class UserAccountConfiguration
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            // TODO This configuration will be wanted at some point.
            //builder.Property(ua => ua.Username)
            //    .IsRequired();

            //builder.Property(ua => ua.Email)
            //    .IsRequired()
            //    .HasMaxLength(320);

            //builder.Property(ua => ua.PasswordHash)
            //    .IsRequired();
        }
    }
}

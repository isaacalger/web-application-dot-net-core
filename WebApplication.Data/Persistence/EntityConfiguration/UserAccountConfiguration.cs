using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Data.Core.EntityModels;

namespace WebApplication.Data.Persistence.EntityConfiguration
{
    public class UserAccountConfiguration
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.Property(ua => ua.Guid)
                .IsRequired();

            builder.Property(ua => ua.Email)
                .IsRequired()
                .HasMaxLength(320);

            builder.Property(ua => ua.PasswordHash)
                .IsRequired();
        }
    }
}

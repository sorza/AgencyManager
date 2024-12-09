using AgencyManager.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Api.Data.Mappings.Identity
{
    public class IdentityUserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("IdentityUser");
            builder.HasKey(u => u.Id);

            builder.Property(u=> u.UserName).IsRequired(true);

            builder.HasIndex(u => u.NormalizedUserName).IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).IsUnique();

            builder.Property(u => u.EmailConfirmed).HasMaxLength(180);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(180);
            builder.Property(u => u.UserName).HasMaxLength(180);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(180);
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            builder.HasMany<IdentityUserClaim<int>>().WithOne().HasForeignKey(u => u.UserId).IsRequired();
            builder.HasMany<IdentityUserLogin<int>>().WithOne().HasForeignKey(u => u.UserId).IsRequired();
            builder.HasMany<IdentityUserToken<int>>().WithOne().HasForeignKey(u => u.UserId).IsRequired();
            builder.HasMany<IdentityUserRole<int>>().WithOne().HasForeignKey(u => u.UserId).IsRequired();
        }
    }
}

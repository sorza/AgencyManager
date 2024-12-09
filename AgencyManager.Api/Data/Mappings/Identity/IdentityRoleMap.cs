using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.Api.Data.Mappings.Identity
{
    public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.ToTable("IdentityRole");
            builder.HasKey(r => r.Id);
            builder.HasIndex(r => r.NormalizedName).IsUnique();
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(r => r.Name).HasMaxLength(256).IsRequired();
            builder.Property(r => r.NormalizedName).HasMaxLength(256);
        }
    }
}

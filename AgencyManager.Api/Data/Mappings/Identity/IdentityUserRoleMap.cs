using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.Api.Data.Mappings.Identity
{
    public class IdentityUserRoleMapping : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.ToTable("IdentityUserRole");
            builder.HasKey(r => new { r.UserId, r.RoleId });
        }
    }
}

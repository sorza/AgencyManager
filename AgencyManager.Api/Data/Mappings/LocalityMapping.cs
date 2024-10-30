using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Api.Data.Mappings
{
    internal class LocalityMapping : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.ToTable("Locality");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.City)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.State)
                .IsRequired(true)
                .HasColumnType("CHAR")
                .HasMaxLength(2);
        }
    }
}

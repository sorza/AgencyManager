using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Api.Data.Mappings
{
    internal class PositionMapping : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(70);

            builder.Property(x => x.Responsabilities)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(500);

            builder.Property(x => x.Salary)
                .IsRequired(true)
                .HasColumnType("DECIMAL");

            builder.Property(x => x.AgencyId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.HasOne(p => p.Agency)
                .WithMany()
                .HasForeignKey(p => p.AgencyId);
        }
    }
}

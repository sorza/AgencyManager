using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Data.Mappings
{
    public class AgencyMapping : IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.ToTable("Agency");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Cnpj)
                .IsRequired(true)
                .HasColumnType("CHAR")
                .HasMaxLength(14);

            builder.Property(x => x.Active)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Property(address => address.ZipCode)
                    .IsRequired(true)
                    .HasColumnType("CHAR")
                    .HasMaxLength(8);

                address.Property(address => address.Street)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                address.Property(address => address.Street)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(7);

                address.Property(address => address.Neighborhood)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(70);

                address.Property(address => address.City)
                    .IsRequired(true)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                address.Property(address => address.State)
                    .IsRequired(true)
                    .HasColumnType("CHAR")
                    .HasMaxLength(2);

                address.Property(address => address.State)
                    .IsRequired(false)
                    .HasColumnType("CHAR")
                    .HasMaxLength(50);
            });

            builder.Property(x => x.Photo)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.HasMany(x => x.Contacts)
                .WithOne(c => c.Agency)
                .HasForeignKey(c => c.AgencyId);

            builder.HasMany(x => x.Positions)
                .WithOne(c => c.Agency)
                .HasForeignKey(c => c.AgencyId);

            builder.HasMany(x => x.Employees)
                .WithOne(c => c.Agency)
                .HasForeignKey(c => c.AgencyId);

            builder.HasMany(x => x.Contracts)
                .WithOne(c => c.Agency)
                .HasForeignKey(c => c.AgencyId);

        }
    }
}

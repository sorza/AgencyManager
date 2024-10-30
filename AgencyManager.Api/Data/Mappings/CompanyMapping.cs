using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Api.Data.Mappings
{
    internal class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.TradingName)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(60);

            builder.Property(x => x.Cnpj)
                .IsRequired(true)
                .HasColumnType("CHAR")
                .HasMaxLength(14);

            builder.Property(x => x.Logo)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.OwnsOne(x => x.Address, address =>
            {
                address.Ignore(x => x.Notifications);

                address.Property(address => address.ZipCode)
                    .IsRequired(true)
                    .HasColumnName("ZipCode")
                    .HasColumnType("CHAR")
                    .HasMaxLength(8);

                address.Property(address => address.Street)
                    .IsRequired(true)
                    .HasColumnName("Street")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                address.Property(address => address.Number)
                    .IsRequired(true)
                    .HasColumnName("Number")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(7);

                address.Property(address => address.Neighborhood)
                    .IsRequired(true)
                    .HasColumnName("Neighborhood")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(70);

                address.Property(address => address.City)
                    .IsRequired(true)
                    .HasColumnName("City")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                address.Property(address => address.State)
                    .IsRequired(true)
                    .HasColumnName("State")
                    .HasColumnType("CHAR")
                    .HasMaxLength(2);

                address.Property(address => address.Complement)
                    .IsRequired(false)
                    .HasColumnName("Complement")
                    .HasColumnType("CHAR")
                    .HasMaxLength(50);
            });

            builder.HasMany(c => c.Contacts)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

        }
    }
}

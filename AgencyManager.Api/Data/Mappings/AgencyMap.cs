using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class AgencyMap : IEntityTypeConfiguration<Agency>
{
    public void Configure(EntityTypeBuilder<Agency> builder)
    {
        builder.ToTable("Agency");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Description)
               .IsRequired()
               .HasColumnType("VARCHAR")
               .HasMaxLength(60);

        builder.Property(x => x.Cnpj)
               .IsRequired()
               .HasColumnType("CHAR")
               .HasMaxLength(14);

        builder.Property(x => x.Active)
               .IsRequired()
               .HasColumnType("BIT");

        builder.Property(x => x.Photo)
            .HasColumnType("NVARCHAR(MAX)");

        builder.OwnsOne(x => x.Address, address =>
        {        
            address.Property(address => address.ZipCode)
                   .IsRequired()
                   .HasColumnName("ZipCode")
                   .HasColumnType("CHAR")
                   .HasMaxLength(8);

            address.Property(address => address.Street)
                   .IsRequired()
                   .HasColumnName("Street")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(100);

            address.Property(address => address.Number)
                   .IsRequired()
                   .HasColumnName("Number")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(7);

            address.Property(address => address.Neighborhood)
                   .IsRequired()
                   .HasColumnName("Neighborhood")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(70);

            address.Property(address => address.City)
                   .IsRequired()
                   .HasColumnName("City")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(100);

            address.Property(address => address.State)
                   .IsRequired()
                   .HasColumnName("State")
                   .HasColumnType("CHAR")
                   .HasMaxLength(2);

            address.Property(address => address.Complement)
                   .IsRequired(false)
                   .HasColumnName("Complement")
                   .HasColumnType("VARCHAR")
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

        builder.HasMany(x => x.Cash)
               .WithOne(c => c.Agency)
               .HasForeignKey(c => c.AgencyId);
    }
}

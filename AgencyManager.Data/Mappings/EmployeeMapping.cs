using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Data.Mappings
{
    internal class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Cpf)
                .IsRequired(true)
                .HasColumnType("CHAR")
                .HasMaxLength(11);

            builder.Property(x => x.Rg)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(14);

            builder.Property(x => x.BirthDay)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.AgencyId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.PositionId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.DateHire)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.DateDismiss)
                .IsRequired(false)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.UserId)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength("60");

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

            builder.HasMany(x => x.Contacts)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.EmployeeId);

            builder.HasOne(c => c.User)
                .WithOne()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Position)
                .WithMany()
                .HasForeignKey(c => c.PositionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

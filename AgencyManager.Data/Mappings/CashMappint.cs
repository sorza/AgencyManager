using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Data.Mappings
{
    internal class CashMappint : IEntityTypeConfiguration<Cash>
    {
        public void Configure(EntityTypeBuilder<Cash> builder)
        {
            builder.ToTable("Cash");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
               .IsRequired(true)
               .HasColumnType("VARCHAR")
               .HasMaxLength(70);

            builder.Property(x => x.Date)
               .IsRequired(true)
               .HasColumnType("DATETIME2");

            builder.Property(x => x.StartValue)
               .IsRequired(true)
               .HasColumnType("MONEY");

            builder.Property(x => x.EndValue)
               .IsRequired(true)
               .HasColumnType("MONEY");

            builder.Property(x => x.Status)
               .IsRequired(true)
               .HasColumnType("BIT");

            builder.HasMany(c => c.Transactions)
                .WithOne(c => c.Cash)
                .HasForeignKey(c => c.CashId);

            builder.HasMany(c => c.Sales)
                .WithOne(c => c.Cash)
                .HasForeignKey(c => c.CashId);

            builder.HasMany(c => c.VirtualSales)
                .WithOne(c => c.Cash)
                .HasForeignKey(c => c.CashId);
        }
    }
}

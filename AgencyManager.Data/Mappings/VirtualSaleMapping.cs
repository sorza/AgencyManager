using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Data.Mappings
{
    internal class VirtualSaleMapping : IEntityTypeConfiguration<VirtualSale>
    {
        public void Configure(EntityTypeBuilder<VirtualSale> builder)
        {
            builder.ToTable("VirtualSale");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CashId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.CompanyId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.OrignId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.DestinationId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.Amount)
                .IsRequired(true)
                .HasColumnType("DECIMAL");

            builder.Property(x => x.PaymentType)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Paid)
                .IsRequired(true)
                .HasColumnType("BIT");

            builder.Property(x => x.CompanyId)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasOne(v => v.Cash)
                .WithMany()
                .HasForeignKey(v => v.CashId);

            builder.HasOne(v => v.Company)
                .WithMany()
                .HasForeignKey(v => v.CompanyId);

            builder.HasOne(v => v.Orign)
                .WithMany()
                .HasForeignKey(v => v.OrignId);

            builder.HasOne(v => v.Destination)
                .WithMany()
                .HasForeignKey(v => v.DestinationId);
        }
    }
}

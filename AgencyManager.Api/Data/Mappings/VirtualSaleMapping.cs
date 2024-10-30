using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class VirtualSaleMapping : IEntityTypeConfiguration<VirtualSale>
{
    public void Configure(EntityTypeBuilder<VirtualSale> builder)
    {
        builder.ToTable("VirtualSales");

        builder.HasKey(vs => vs.Id);

        builder.Property(vs => vs.CashId)
               .IsRequired()
               .HasColumnType("INT");

        builder.Property(vs => vs.CompanyId)
               .IsRequired()
               .HasColumnType("INT");

        builder.Property(vs => vs.Amount)
               .IsRequired()
               .HasColumnType("DECIMAL");

        builder.Property(vs => vs.PaymentType)
               .IsRequired()
               .HasColumnType("INT");

        builder.Property(vs => vs.Paid)
               .IsRequired()
               .HasColumnType("BIT");

        builder.Property(vs => vs.Observation)
               .HasColumnType("VARCHAR(500)");

        builder.HasOne(vs => vs.Orign)
               .WithMany()
               .HasForeignKey(vs => vs.OrignId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(vs => vs.Destination)
               .WithMany()
               .HasForeignKey(vs => vs.DestinationId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}

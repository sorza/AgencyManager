using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Api.Data.Mappings
{
    internal class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sale");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CashId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.CompanyId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.Money)
                .IsRequired(true)
                .HasColumnType("MONEY");

            builder.Property(x => x.Digital)
                .IsRequired(true)
                .HasColumnType("MONEY");
        }
    }
}

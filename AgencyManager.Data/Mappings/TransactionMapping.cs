using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Data.Mappings
{
    internal class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CashId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.Type)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Amount)
                .IsRequired(true)
                .HasColumnType("DECIMAL");

            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasOne(t => t.Cash)
                .WithMany()
                .HasForeignKey(t => t.CashId);

        }
    }
}

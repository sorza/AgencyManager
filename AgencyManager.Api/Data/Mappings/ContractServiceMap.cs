using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Api.Data.Mappings
{
    internal class ContractServiceMap : IEntityTypeConfiguration<ContractService>
    {
        public void Configure(EntityTypeBuilder<ContractService> builder)
        {
            builder.ToTable("Contract");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Active)
                .IsRequired(true)
                .HasColumnType("BIT");

            builder.Property(x => x.AgencyId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.CompanyId)
                .IsRequired(true)
                .HasColumnType("INT");

            builder.Property(x => x.Comission)
                .IsRequired(true)
                .HasColumnType("DECIMAL");

            builder.Property(x => x.ServiceType)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.StartDate)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(x => x.EndDate)
                .IsRequired(false)
                .HasColumnType("DATETIME2");

            builder.HasOne(c => c.Agency)
                .WithMany()
                .HasForeignKey(c => c.AgencyId);

            builder.HasOne(c => c.Company)
                .WithMany()
                .HasForeignKey(c => c.CompanyId);
        }
    }
}

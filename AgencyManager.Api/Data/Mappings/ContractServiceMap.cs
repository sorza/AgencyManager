using AgencyManager.Core.Models.Entities;
using AgencyManager.Core.Models.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Net;

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

            builder.Property(x => x.DailyPayment)
                .IsRequired(true)
                .HasColumnType("BIT");

            builder.Property(x => x.DailyComission)
                .IsRequired(true)
                .HasColumnType("BIT");

            builder.Property(x => x.Nfe)
                .IsRequired(true)
                .HasColumnType("BIT");            

            builder.OwnsOne(cs => cs.NfeData, nfe =>
            {
                nfe.Property(nd => nd.Name)
                   .IsRequired(false)
                   .HasColumnName("CompanyName")
                   .HasColumnType("VARCHAR")
                   .HasMaxLength(60);

                nfe.Property(nd => nd.Cnpj)
                    .IsRequired(false)
                    .HasColumnName("CompanyCnpj")
                    .HasColumnType("CHAR")
                    .HasMaxLength(14);

                nfe.Property(nd => nd.Ie)
                    .IsRequired(false)
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(15);

                nfe.Property(nd => nd.ZipCode)
                   .IsRequired(true)
                   .HasColumnName("ZipCode")
                   .HasColumnType("CHAR")
                   .HasMaxLength(8);

                nfe.Property(nd => nd.Street)
                    .IsRequired(true)
                    .HasColumnName("Street")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                nfe.Property(nd => nd.Number)
                    .IsRequired(true)
                    .HasColumnName("Number")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(7);

                nfe.Property(nd => nd.Neighborhood)
                    .IsRequired(true)
                    .HasColumnName("Neighborhood")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(70);

                nfe.Property(nd => nd.City)
                    .IsRequired(true)
                    .HasColumnName("City")
                    .HasColumnType("VARCHAR")
                    .HasMaxLength(100);

                nfe.Property(nd => nd.State)
                    .IsRequired(true)
                    .HasColumnName("State")
                    .HasColumnType("CHAR")
                    .HasMaxLength(2);

                nfe.Property(nd => nd.Complement)
                    .IsRequired(false)
                    .HasColumnName("Complement")
                    .HasColumnType("CHAR")
                    .HasMaxLength(50);
            });

            builder.HasOne(cs => cs.Agency)
                .WithMany() 
                .HasForeignKey(cs => cs.AgencyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cs => cs.Company)
                   .WithMany() 
                   .HasForeignKey(cs => cs.CompanyId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

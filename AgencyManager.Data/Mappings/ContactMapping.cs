﻿using AgencyManager.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgencyManager.Data.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contact");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ContactType)
                .IsRequired(true)
                .HasColumnType("SMALLINT");

            builder.Property(x => x.Description)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(70);

            builder.Property(x=> x.Departament)
                .IsRequired(true)
                .HasColumnType("VARCHAR")
                .HasMaxLength(70);
        }
    }
}

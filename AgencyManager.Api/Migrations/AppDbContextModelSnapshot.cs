﻿// <auto-generated />
using System;
using AgencyManager.Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgencyManager.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Agency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("CHAR");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Photo")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Agency", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Cash", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATETIME2");

                    b.Property<decimal>("EndValue")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("StartValue")
                        .HasColumnType("MONEY");

                    b.Property<bool>("Status")
                        .HasColumnType("BIT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Cash", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("CHAR");

                    b.Property<string>("Logo")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("TradingName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Company", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgencyId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<short>("ContactType")
                        .HasColumnType("SMALLINT");

                    b.Property<string>("Departament")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.ContractService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("BIT");

                    b.Property<int>("AgencyId")
                        .HasColumnType("INT");

                    b.Property<decimal>("Comission")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("DATETIME2");

                    b.Property<short>("ServiceType")
                        .HasColumnType("SMALLINT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("DATETIME2");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Contract", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AgencyId")
                        .HasColumnType("INT");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("CHAR");

                    b.Property<DateTime>("DateDismiss")
                        .HasColumnType("DATETIME2");

                    b.Property<DateTime>("DateHire")
                        .HasColumnType("DATETIME2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("PositionId")
                        .HasColumnType("INT");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Locality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("CHAR");

                    b.HasKey("Id");

                    b.ToTable("Localities", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgencyId")
                        .HasColumnType("INT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Responsabilities")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("Salary")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("Positions", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CashId")
                        .HasColumnType("INT");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INT");

                    b.Property<decimal>("Digital")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Money")
                        .HasColumnType("MONEY");

                    b.HasKey("Id");

                    b.HasIndex("CashId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("CashId")
                        .HasColumnType("INT");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR");

                    b.Property<short>("Type")
                        .HasColumnType("SMALLINT");

                    b.HasKey("Id");

                    b.HasIndex("CashId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.VirtualSale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL");

                    b.Property<int>("CashId")
                        .HasColumnType("INT");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INT");

                    b.Property<int>("DestinationId")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .HasColumnType("VARCHAR(500)");

                    b.Property<int>("OrignId")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("BIT");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.HasIndex("CashId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DestinationId");

                    b.HasIndex("OrignId");

                    b.ToTable("VirtualSales", (string)null);
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Agency", b =>
                {
                    b.OwnsOne("AgencyManager.Core.Models.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("AgencyId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .HasMaxLength(50)
                                .HasColumnType("CHAR")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Neighborhood");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(7)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("CHAR")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("CHAR")
                                .HasColumnName("ZipCode");

                            b1.HasKey("AgencyId");

                            b1.ToTable("Agency");

                            b1.WithOwner()
                                .HasForeignKey("AgencyId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Company", b =>
                {
                    b.OwnsOne("AgencyManager.Core.Models.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CompanyId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .HasMaxLength(50)
                                .HasColumnType("CHAR")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Neighborhood");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(7)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("CHAR")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("CHAR")
                                .HasColumnName("ZipCode");

                            b1.HasKey("CompanyId");

                            b1.ToTable("Company");

                            b1.WithOwner()
                                .HasForeignKey("CompanyId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Contact", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Agency", "Agency")
                        .WithMany("Contacts")
                        .HasForeignKey("AgencyId");

                    b.HasOne("AgencyManager.Core.Models.Entities.Company", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId");

                    b.HasOne("AgencyManager.Core.Models.Entities.Employee", "Employee")
                        .WithMany("Contacts")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Agency");

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.ContractService", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Agency", "Agency")
                        .WithMany("Contracts")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgencyManager.Core.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Employee", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Agency", "Agency")
                        .WithMany("Employees")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgencyManager.Core.Models.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("AgencyManager.Core.Models.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("EmployeeId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("City");

                            b1.Property<string>("Complement")
                                .HasMaxLength(50)
                                .HasColumnType("CHAR")
                                .HasColumnName("Complement");

                            b1.Property<string>("Neighborhood")
                                .IsRequired()
                                .HasMaxLength(70)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Neighborhood");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasMaxLength(7)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Number");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasMaxLength(2)
                                .HasColumnType("CHAR")
                                .HasColumnName("State");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("CHAR")
                                .HasColumnName("ZipCode");

                            b1.HasKey("EmployeeId");

                            b1.ToTable("Employee");

                            b1.WithOwner()
                                .HasForeignKey("EmployeeId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Agency");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Position", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Agency", "Agency")
                        .WithMany("Positions")
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Sale", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Cash", "Cash")
                        .WithMany("Sales")
                        .HasForeignKey("CashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgencyManager.Core.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cash");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Transaction", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Cash", "Cash")
                        .WithMany("Transactions")
                        .HasForeignKey("CashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cash");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.VirtualSale", b =>
                {
                    b.HasOne("AgencyManager.Core.Models.Entities.Cash", "Cash")
                        .WithMany("VirtualSales")
                        .HasForeignKey("CashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgencyManager.Core.Models.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgencyManager.Core.Models.Entities.Locality", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgencyManager.Core.Models.Entities.Locality", "Orign")
                        .WithMany()
                        .HasForeignKey("OrignId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cash");

                    b.Navigation("Company");

                    b.Navigation("Destination");

                    b.Navigation("Orign");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Agency", b =>
                {
                    b.Navigation("Contacts");

                    b.Navigation("Contracts");

                    b.Navigation("Employees");

                    b.Navigation("Positions");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Cash", b =>
                {
                    b.Navigation("Sales");

                    b.Navigation("Transactions");

                    b.Navigation("VirtualSales");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Company", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("AgencyManager.Core.Models.Entities.Employee", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}

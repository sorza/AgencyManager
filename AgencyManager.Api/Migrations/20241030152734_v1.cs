using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Cnpj = table.Column<string>(type: "CHAR(14)", maxLength: 14, nullable: false),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    ZipCode = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    Complement = table.Column<string>(type: "CHAR(50)", maxLength: 50, nullable: true),
                    Photo = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    TradingName = table.Column<string>(type: "VARCHAR(60)", maxLength: 60, nullable: false),
                    Cnpj = table.Column<string>(type: "CHAR(14)", maxLength: 14, nullable: false),
                    ZipCode = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    Complement = table.Column<string>(type: "CHAR(50)", maxLength: 50, nullable: true),
                    Logo = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cash",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    StartValue = table.Column<decimal>(type: "MONEY", nullable: false),
                    EndValue = table.Column<decimal>(type: "MONEY", nullable: false),
                    Status = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cash", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cash_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    Responsabilities = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Salary = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    AgencyId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "BIT", nullable: false),
                    AgencyId = table.Column<int>(type: "INT", nullable: false),
                    CompanyId = table.Column<int>(type: "INT", nullable: false),
                    ServiceType = table.Column<short>(type: "SMALLINT", nullable: false),
                    Comission = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "DATETIME2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashId = table.Column<int>(type: "INT", nullable: false),
                    CompanyId = table.Column<int>(type: "INT", nullable: false),
                    Money = table.Column<decimal>(type: "MONEY", nullable: false),
                    Digital = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Cash_CashId",
                        column: x => x.CashId,
                        principalTable: "Cash",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashId = table.Column<int>(type: "INT", nullable: false),
                    Type = table.Column<short>(type: "SMALLINT", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Cash_CashId",
                        column: x => x.CashId,
                        principalTable: "Cash",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VirtualSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CashId = table.Column<int>(type: "INT", nullable: false),
                    CompanyId = table.Column<int>(type: "INT", nullable: false),
                    OrignId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(18,0)", nullable: false),
                    PaymentType = table.Column<int>(type: "INT", nullable: false),
                    Paid = table.Column<bool>(type: "BIT", nullable: false),
                    Observation = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VirtualSale_Cash_CashId",
                        column: x => x.CashId,
                        principalTable: "Cash",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualSale_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualSale_Locality_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Locality",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VirtualSale_Locality_OrignId",
                        column: x => x.OrignId,
                        principalTable: "Locality",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "CHAR(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    BirthDay = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    ZipCode = table.Column<string>(type: "CHAR(8)", maxLength: 8, nullable: false),
                    Street = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(7)", maxLength: 7, nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    City = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "CHAR(2)", maxLength: 2, nullable: false),
                    Complement = table.Column<string>(type: "CHAR(50)", maxLength: 50, nullable: true),
                    AgencyId = table.Column<int>(type: "INT", nullable: false),
                    PositionId = table.Column<int>(type: "INT", nullable: false),
                    DateHire = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    DateDismiss = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactType = table.Column<short>(type: "SMALLINT", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    Departament = table.Column<string>(type: "VARCHAR(70)", maxLength: 70, nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Agency_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agency",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cash_AgencyId",
                table: "Cash",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AgencyId",
                table: "Contact",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CompanyId",
                table: "Contact",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_EmployeeId",
                table: "Contact",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_AgencyId",
                table: "Contract",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CompanyId",
                table: "Contract",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AgencyId",
                table: "Employee",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_AgencyId",
                table: "Position",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CashId",
                table: "Sale",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CompanyId",
                table: "Sale",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CashId",
                table: "Transaction",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSale_CashId",
                table: "VirtualSale",
                column: "CashId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSale_CompanyId",
                table: "VirtualSale",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSale_DestinationId",
                table: "VirtualSale",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualSale_OrignId",
                table: "VirtualSale",
                column: "OrignId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "VirtualSale");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Cash");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Locality");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Agency");
        }
    }
}

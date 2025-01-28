using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class v34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contract",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCnpj",
                table: "Contract",
                type: "CHAR(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Contract",
                type: "VARCHAR(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Contract",
                type: "CHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Contract",
                type: "VARCHAR(70)",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NfeData_Ie",
                table: "Contract",
                type: "VARCHAR(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Contract",
                type: "VARCHAR(7)",
                maxLength: 7,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Contract",
                type: "CHAR(2)",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Contract",
                type: "VARCHAR(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Contract",
                type: "CHAR(8)",
                maxLength: 8,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "CompanyCnpj",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "NfeData_Ie",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Contract");
        }
    }
}

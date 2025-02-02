using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompanyCnpj",
                table: "Contract",
                type: "CHAR(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Responsible",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Responsible",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyCnpj",
                table: "Contract",
                type: "CHAR(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(14)",
                oldMaxLength: 14,
                oldNullable: true);
        }
    }
}

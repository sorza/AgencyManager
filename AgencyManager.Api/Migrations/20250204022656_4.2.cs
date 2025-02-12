using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class _42 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Employee",
                type: "VARCHAR(180)",
                maxLength: 180,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Responsible",
                table: "Contact",
                type: "VARCHAR(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "Responsible",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(70)",
                oldMaxLength: 70);
        }
    }
}

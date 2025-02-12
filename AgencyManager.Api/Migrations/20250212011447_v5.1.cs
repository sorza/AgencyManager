using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyManager.Api.Migrations
{
    /// <inheritdoc />
    public partial class v51 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserKey",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "UserLogin",
                table: "Employee",
                type: "VARCHAR(180)",
                maxLength: 180,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserLogin",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "UserKey",
                table: "Employee",
                type: "int",
                nullable: true);
        }
    }
}

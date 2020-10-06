using Microsoft.EntityFrameworkCore.Migrations;

namespace Auth0API.Infrastructure.Migrations
{
    public partial class UpdateEmployeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employee");
        }
    }
}

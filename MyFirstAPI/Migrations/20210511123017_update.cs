using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFirstAPI.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "Users",
                newName: "CityofOrigin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityofOrigin",
                table: "Users",
                newName: "City");
        }
    }
}

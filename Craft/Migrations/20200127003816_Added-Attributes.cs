using Microsoft.EntityFrameworkCore.Migrations;

namespace Craft.Migrations
{
    public partial class AddedAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HardwareComponents",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "FilterCategories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Primary",
                table: "ComponentSpecifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "HardwareComponents");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "FilterCategories");

            migrationBuilder.DropColumn(
                name: "Primary",
                table: "ComponentSpecifications");
        }
    }
}

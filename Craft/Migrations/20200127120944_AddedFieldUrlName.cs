using Microsoft.EntityFrameworkCore.Migrations;

namespace Craft.Migrations
{
    public partial class AddedFieldUrlName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlName",
                table: "HardwareUnits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeyWords",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "Articles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlName",
                table: "HardwareUnits");

            migrationBuilder.DropColumn(
                name: "KeyWords",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "Articles");
        }
    }
}

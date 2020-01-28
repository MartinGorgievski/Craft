using Microsoft.EntityFrameworkCore.Migrations;

namespace Craft.Migrations
{
    public partial class AddedFKToFliterCatFromHardComp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HardwareComponentId",
                table: "FilterCategories",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FilterCategories_HardwareComponentId",
                table: "FilterCategories",
                column: "HardwareComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilterCategories_HardwareComponents_HardwareComponentId",
                table: "FilterCategories",
                column: "HardwareComponentId",
                principalTable: "HardwareComponents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterCategories_HardwareComponents_HardwareComponentId",
                table: "FilterCategories");

            migrationBuilder.DropIndex(
                name: "IX_FilterCategories_HardwareComponentId",
                table: "FilterCategories");

            migrationBuilder.DropColumn(
                name: "HardwareComponentId",
                table: "FilterCategories");
        }
    }
}

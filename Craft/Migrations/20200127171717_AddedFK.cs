using Microsoft.EntityFrameworkCore.Migrations;

namespace Craft.Migrations
{
    public partial class AddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterComponents_FilterCategories_FilterCategoryId",
                table: "FilterComponents");

            migrationBuilder.AlterColumn<int>(
                name: "FilterCategoryId",
                table: "FilterComponents",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FilterComponents_FilterCategories_FilterCategoryId",
                table: "FilterComponents",
                column: "FilterCategoryId",
                principalTable: "FilterCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilterComponents_FilterCategories_FilterCategoryId",
                table: "FilterComponents");

            migrationBuilder.AlterColumn<int>(
                name: "FilterCategoryId",
                table: "FilterComponents",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FilterComponents_FilterCategories_FilterCategoryId",
                table: "FilterComponents",
                column: "FilterCategoryId",
                principalTable: "FilterCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Craft.Migrations
{
    public partial class FixRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComponentSpecifications_FilterComponents_FilterComponentId",
                table: "ComponentSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_ComponentSpecifications_FilterComponentId",
                table: "ComponentSpecifications");

            migrationBuilder.DropColumn(
                name: "FilterComponentId",
                table: "ComponentSpecifications");

            migrationBuilder.AddColumn<int>(
                name: "FilterComponentId",
                table: "HardwareUnitSpecification",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HardwareUnitSpecification_FilterComponentId",
                table: "HardwareUnitSpecification",
                column: "FilterComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareUnitSpecification_FilterComponents_FilterComponentId",
                table: "HardwareUnitSpecification",
                column: "FilterComponentId",
                principalTable: "FilterComponents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareUnitSpecification_FilterComponents_FilterComponentId",
                table: "HardwareUnitSpecification");

            migrationBuilder.DropIndex(
                name: "IX_HardwareUnitSpecification_FilterComponentId",
                table: "HardwareUnitSpecification");

            migrationBuilder.DropColumn(
                name: "FilterComponentId",
                table: "HardwareUnitSpecification");

            migrationBuilder.AddColumn<int>(
                name: "FilterComponentId",
                table: "ComponentSpecifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSpecifications_FilterComponentId",
                table: "ComponentSpecifications",
                column: "FilterComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComponentSpecifications_FilterComponents_FilterComponentId",
                table: "ComponentSpecifications",
                column: "FilterComponentId",
                principalTable: "FilterComponents",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

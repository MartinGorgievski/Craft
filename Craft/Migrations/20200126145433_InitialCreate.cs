using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Craft.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameCategory = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentSpecificationCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentSpecificationCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FilterCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HardwareComponents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareComponents", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    Descriprion = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    CategoryNewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_CategoryNews_CategoryNewsId",
                        column: x => x.CategoryNewsId,
                        principalTable: "CategoryNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterComponents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FilterCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterComponents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FilterComponents_FilterCategories_FilterCategoryId",
                        column: x => x.FilterCategoryId,
                        principalTable: "FilterCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HardwareUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    HardwareComponentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareUnits_HardwareComponents_HardwareComponentId",
                        column: x => x.HardwareComponentId,
                        principalTable: "HardwareComponents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComponentSpecifications",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeName = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    HardwareComponentId = table.Column<int>(nullable: false),
                    FilterComponentId = table.Column<int>(nullable: false),
                    ComponentSpecificationCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentSpecifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComponentSpecifications_ComponentSpecificationCategories_ComponentSpecificationCategoryId",
                        column: x => x.ComponentSpecificationCategoryId,
                        principalTable: "ComponentSpecificationCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentSpecifications_FilterComponents_FilterComponentId",
                        column: x => x.FilterComponentId,
                        principalTable: "FilterComponents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComponentSpecifications_HardwareComponents_HardwareComponentId",
                        column: x => x.HardwareComponentId,
                        principalTable: "HardwareComponents",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HardwareUnitSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeValue = table.Column<string>(nullable: true),
                    ShortInfo = table.Column<string>(nullable: true),
                    HardwareUnitId = table.Column<int>(nullable: false),
                    ComponentSpecificationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareUnitSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HardwareUnitSpecification_ComponentSpecifications_ComponentSpecificationId",
                        column: x => x.ComponentSpecificationId,
                        principalTable: "ComponentSpecifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HardwareUnitSpecification_HardwareUnits_HardwareUnitId",
                        column: x => x.HardwareUnitId,
                        principalTable: "HardwareUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryNewsId",
                table: "Articles",
                column: "CategoryNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSpecifications_ComponentSpecificationCategoryId",
                table: "ComponentSpecifications",
                column: "ComponentSpecificationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSpecifications_FilterComponentId",
                table: "ComponentSpecifications",
                column: "FilterComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComponentSpecifications_HardwareComponentId",
                table: "ComponentSpecifications",
                column: "HardwareComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_FilterComponents_FilterCategoryId",
                table: "FilterComponents",
                column: "FilterCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareUnits_HardwareComponentId",
                table: "HardwareUnits",
                column: "HardwareComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareUnitSpecification_ComponentSpecificationId",
                table: "HardwareUnitSpecification",
                column: "ComponentSpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_HardwareUnitSpecification_HardwareUnitId",
                table: "HardwareUnitSpecification",
                column: "HardwareUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "HardwareUnitSpecification");

            migrationBuilder.DropTable(
                name: "CategoryNews");

            migrationBuilder.DropTable(
                name: "ComponentSpecifications");

            migrationBuilder.DropTable(
                name: "HardwareUnits");

            migrationBuilder.DropTable(
                name: "ComponentSpecificationCategories");

            migrationBuilder.DropTable(
                name: "FilterComponents");

            migrationBuilder.DropTable(
                name: "HardwareComponents");

            migrationBuilder.DropTable(
                name: "FilterCategories");
        }
    }
}

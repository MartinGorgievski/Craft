﻿// <auto-generated />
using System;
using Craft.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Craft.Migrations
{
    [DbContext(typeof(CraftMyPcContext))]
    partial class CraftMyPcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Craft.Models.Articles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<int>("CategoryNewsId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Descriprion");

                    b.Property<string>("ImageName");

                    b.Property<string>("KeyWords");

                    b.Property<string>("MetaDescription");

                    b.Property<string>("MetaTitle");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("CategoryNewsId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("Craft.Models.CategoryNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("NameCategory");

                    b.HasKey("Id");

                    b.ToTable("CategoryNews");
                });

            modelBuilder.Entity("Craft.Models.ComponentSpecification", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttributeName");

                    b.Property<int>("ComponentSpecificationCategoryId");

                    b.Property<DateTime>("DateAdded");

                    b.Property<int>("FilterComponentId");

                    b.Property<int>("HardwareComponentId");

                    b.Property<bool>("Primary");

                    b.HasKey("ID");

                    b.HasIndex("ComponentSpecificationCategoryId");

                    b.HasIndex("FilterComponentId");

                    b.HasIndex("HardwareComponentId");

                    b.ToTable("ComponentSpecifications");
                });

            modelBuilder.Entity("Craft.Models.ComponentSpecificationCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("ComponentSpecificationCategories");
                });

            modelBuilder.Entity("Craft.Models.FilterCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FilterCategories");
                });

            modelBuilder.Entity("Craft.Models.FilterComponent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FilterCategoryId");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("FilterCategoryId");

                    b.ToTable("FilterComponents");
                });

            modelBuilder.Entity("Craft.Models.HardwareComponent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("HardwareComponents");
                });

            modelBuilder.Entity("Craft.Models.HardwareUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<int>("HardwareComponentId");

                    b.Property<string>("ImageName");

                    b.Property<string>("Title");

                    b.Property<string>("UrlName");

                    b.HasKey("Id");

                    b.HasIndex("HardwareComponentId");

                    b.ToTable("HardwareUnits");
                });

            modelBuilder.Entity("Craft.Models.HardwareUnitSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AttributeValue");

                    b.Property<int>("ComponentSpecificationId");

                    b.Property<int>("HardwareUnitId");

                    b.Property<string>("ShortInfo");

                    b.HasKey("Id");

                    b.HasIndex("ComponentSpecificationId");

                    b.HasIndex("HardwareUnitId");

                    b.ToTable("HardwareUnitSpecification");
                });

            modelBuilder.Entity("Craft.Models.Articles", b =>
                {
                    b.HasOne("Craft.Models.CategoryNews", "CategoryNews")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryNewsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Craft.Models.ComponentSpecification", b =>
                {
                    b.HasOne("Craft.Models.ComponentSpecificationCategory", "ComponentSpecificationCategory")
                        .WithMany("ComponentSpecification")
                        .HasForeignKey("ComponentSpecificationCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Craft.Models.FilterComponent", "FilterComponent")
                        .WithMany("ComponentSpecifications")
                        .HasForeignKey("FilterComponentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Craft.Models.HardwareComponent", "HardwareComponent")
                        .WithMany("ComponentSpecifications")
                        .HasForeignKey("HardwareComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Craft.Models.FilterComponent", b =>
                {
                    b.HasOne("Craft.Models.FilterCategory")
                        .WithMany("FilterComponents")
                        .HasForeignKey("FilterCategoryId");
                });

            modelBuilder.Entity("Craft.Models.HardwareUnit", b =>
                {
                    b.HasOne("Craft.Models.HardwareComponent", "HardwareComponent")
                        .WithMany()
                        .HasForeignKey("HardwareComponentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Craft.Models.HardwareUnitSpecification", b =>
                {
                    b.HasOne("Craft.Models.ComponentSpecification", "ComponentSpecification")
                        .WithMany("HardwareUnitSpecifications")
                        .HasForeignKey("ComponentSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Craft.Models.HardwareUnit", "HardwareUnit")
                        .WithMany("HardwareUnitSpecifications")
                        .HasForeignKey("HardwareUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

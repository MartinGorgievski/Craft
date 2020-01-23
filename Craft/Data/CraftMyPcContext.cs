using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Craft.Models;

namespace Craft.Data
{
    public class CraftMyPcContext : DbContext
    {
        public CraftMyPcContext(DbContextOptions<CraftMyPcContext> options)
            : base(options)
        {
        }

        public DbSet<Articles> Articles { get; set; }
        public DbSet<CategoryNews> CategoryNews { get; set; }
        public DbSet<ComponentSpecification> ComponentSpecifications { get; set; }
        public DbSet<ComponentSpecificationCategory> ComponentSpecificationCategories { get; set; }
        public DbSet<FilterCategory> FilterCategories { get; set; }
        public DbSet<FilterComponent> FilterComponents { get; set; }
        public DbSet<HardwareComponent> HardwareComponents { get; set; }
        public DbSet<HardwareUnit> HardwareUnits { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;
using Craft.Data;
using Microsoft.EntityFrameworkCore;

namespace Craft.Services
{
    public class FliterCategoriesServices : ICategoryFilter
    {
        private readonly CraftMyPcContext _context;

        public FliterCategoriesServices(CraftMyPcContext context)
        {
            _context = context;
        }

        public async Task<List<FilterCategory>> getFilterCategoriesForHardwareComponent(int hardwareId)
        {
            return await _context.FilterCategories.Include(s => s.FilterComponents)
                                 .Where(s => s.HardwareComponent.ID == hardwareId && s.Active == true).ToListAsync();
        }
    }
}

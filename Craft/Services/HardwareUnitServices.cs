using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;
using Craft.Data;
using Microsoft.EntityFrameworkCore;

namespace Craft.Services
{
    public class HardwareUnitServices : IHardwareUnit
    {
        private readonly CraftMyPcContext _context;

        public HardwareUnitServices(CraftMyPcContext context)
        {
            _context = context;
        }

        public async Task<List<HardwareUnit>> GetHardwareUnitsByTypeAsync(int HardwareCompID)
        {
            var model = await _context.HardwareUnits
                                .Include(s => s.HardwareUnitSpecifications)
                                .ThenInclude(g => g.ComponentSpecification)
                                .Where(s => s.Active == true && s.HardwareComponentId == HardwareCompID).ToListAsync();
            return model;
        }
    }
}

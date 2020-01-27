using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;
using Craft.Data;
using Microsoft.EntityFrameworkCore;

namespace Craft.Services
{
    public class HardwareComponentServices : IHardwareComponent
    {
        private readonly CraftMyPcContext _context;
        
        public HardwareComponentServices(CraftMyPcContext context)
        {
            _context = context;
        }

        public async Task<int> GetHardwareComponentId(string Name)
        {

            return await _context.HardwareComponents
                                         .Where(s => s.Name.ToLower().Trim() == Name.ToLower().Trim())
                                         .Select(s => s.ID)
                                         .FirstOrDefaultAsync();
           
        }
    }
}

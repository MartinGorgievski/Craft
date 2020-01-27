using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;
namespace Craft.Services
{
    public interface IHardwareUnit
    {
        Task<List<HardwareUnit>> GetHardwareUnitsByTypeAsync(int HardwareCompID);
    }
}

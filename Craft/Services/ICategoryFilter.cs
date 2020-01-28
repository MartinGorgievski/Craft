using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;
namespace Craft.Services
{
    public interface ICategoryFilter
    {
        Task<List<FilterCategory>> getFilterCategoriesForHardwareComponent(int hardwareId);
    }
}

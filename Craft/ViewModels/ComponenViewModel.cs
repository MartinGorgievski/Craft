using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;

namespace Craft.ViewModels
{
    public class ComponenViewModel
    {
        public List<HardwareUnit> HardwareUnits { get; set; }
        public List<FilterCategory> FilterCategories { get; set; }
    }
}

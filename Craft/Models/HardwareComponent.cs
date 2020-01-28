using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class HardwareComponent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }

        public ICollection<FilterCategory> FilterCategories { get; set; }
        public ICollection<ComponentSpecification> ComponentSpecifications { get; set; }
       // public ICollection<HardwareUnit> HardwareUnits { get; set; }
    }
}

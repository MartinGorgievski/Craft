using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class FilterComponent
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int FilterCategoryId { get; set; }
        public FilterCategory FilterCategory { get; set; }

        public ICollection<HardwareUnitSpecification> HardwareUnitSpecification { get; set; }


    }
}

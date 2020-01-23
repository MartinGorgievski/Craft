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

        public int HardwareComponentId { get; set; }
        public HardwareComponent HardwareComponent { get; set; }

        public int FilterCategoryId { get; set; }
        public FilterCategory FilterCategory { get; set; }

        public int ComponentSpecificationId { get; set; }
        public ComponentSpecification ComponentSpecification { get; set; }
    }
}

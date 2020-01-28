using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class ComponentSpecification
    {
        public int ID { get; set; }
        public string AttributeName { get; set; }
        public DateTime DateAdded { get; set; }
        public bool Primary { get; set; }

        public int HardwareComponentId { get; set; }
        public HardwareComponent HardwareComponent { get; set; }

        public int ComponentSpecificationCategoryId { get; set; }
        public ComponentSpecificationCategory ComponentSpecificationCategory { get; set; }
    }
}

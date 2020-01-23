using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class ComponentSpecificationCategory
    {
        public int  ID { get; set; }
        public string Name { get; set; }

        //public int HardwareComponentId { get; set; }
        //public HardwareComponent HardwareComponent { get; set; }
        
        public ICollection<ComponentSpecification> ComponentSpecification { get; set; }
    }
}

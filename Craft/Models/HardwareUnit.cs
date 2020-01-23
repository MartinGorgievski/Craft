using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class HardwareUnit
    {
        public int ID { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }

        public int HardwareComponentId { get; set; }
        public HardwareComponent HardwareComponent { get; set; }

        public ICollection<ComponentSpecification> ComponentSpecifications { get; set; }
    }
}

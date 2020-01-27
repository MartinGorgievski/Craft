using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class HardwareUnit
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }

        public int HardwareComponentId { get; set; }
        public HardwareComponent HardwareComponent { get; set; }

        public ICollection<HardwareUnitSpecification> HardwareUnitSpecifications { get; set; }
       
    }
}

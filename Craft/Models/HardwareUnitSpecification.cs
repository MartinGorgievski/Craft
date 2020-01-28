using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class HardwareUnitSpecification
    {
        [Key]
        public int Id { get; set; }
        public string AttributeValue { get; set; }
        public string ShortInfo { get; set; }

        public int FilterComponentId { get; set; }
        public FilterComponent FilterComponent { get; set; }

        public int HardwareUnitId { get; set; }
        public HardwareUnit HardwareUnit { get; set; }

        public int ComponentSpecificationId { get; set; }
        public ComponentSpecification ComponentSpecification { get; set; }
    }
}

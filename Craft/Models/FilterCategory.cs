using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class FilterCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public ICollection<FilterComponent> FilterComponents { get; set; }
    }
}

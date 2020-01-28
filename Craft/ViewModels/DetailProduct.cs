using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Models;
namespace Craft.ViewModels
{
    public class DetailProduct
    {
        public HardwareUnit HardwareUnit { get; set; }
        public List<ComponentSpecificationCategory> ComponentSpecificationCategory { get; set; }
    }
}

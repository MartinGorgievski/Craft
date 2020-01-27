using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class Menu
    {
        //Ne e dodadena vo context klasata
        public int Id { get; set; }
        public string Name { get; set; }
        // Meta data - where is the menu in header or in main menu
        public string MenuPosition { get; set; }
        public bool Active { get; set; }

    }
}

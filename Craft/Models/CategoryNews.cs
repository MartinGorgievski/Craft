using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class CategoryNews
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public DateTime DateAdded { get; set; }

        public ICollection<Articles> Articles { get; set; }
    }
}

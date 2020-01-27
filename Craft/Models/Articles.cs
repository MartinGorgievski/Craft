using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craft.Models
{
    public class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public string Descriprion { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string KeyWords { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
        public string Author { get; set; }

        public int CategoryNewsId { get; set; }
        public CategoryNews CategoryNews { get; set; }
    }
}

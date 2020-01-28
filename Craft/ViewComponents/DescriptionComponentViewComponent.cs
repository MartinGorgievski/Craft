using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Craft.Data;
using Craft.Models;
using Microsoft.EntityFrameworkCore;

namespace Craft.ViewComponents
{
    public class DescriptionComponentViewComponent : ViewComponent
    {
        private readonly CraftMyPcContext db;

        public DescriptionComponentViewComponent(CraftMyPcContext context)
        {
            db = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int ComponentId)
        {
            //var model = db.BookieBonus.Include(s => s.BookMaker).OrderByDescending(s => s.DateAdded).Take(10).ToList();
            var model = db.HardwareComponents.Find(ComponentId);

            return await Task.FromResult((IViewComponentResult)View("Default", model));
        }


    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Craft.Models;
using Craft.Data;
using Microsoft.EntityFrameworkCore;

namespace Craft.Controllers
{
    public class HomeController : Controller
    {
        private readonly CraftMyPcContext _context;

        public HomeController(CraftMyPcContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Component()
        {
            var model = _context.HardwareUnits.Include(s => s.HardwareUnitSpecifications)
                                .Where(s => s.Active == true);

            return View(await model.ToListAsync());
        }
        //public async Task<IActionResult> Index()
        //{
        //    var craftMyPcContext = _context.HardwareUnits.Include(h => h.HardwareComponent);
        //    return View(await craftMyPcContext.ToListAsync());
        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

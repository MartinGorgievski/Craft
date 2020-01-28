using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Craft.Models;
using Craft.Data;
using Microsoft.EntityFrameworkCore;
namespace Craft.Controllers
{
    public class NewsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public NewsController(CraftMyPcContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AllNews(int? pageid)
        {
            var model = _context.Articles.Include(s => s.CategoryNews).OrderByDescending(s => s.DateAdded);
            return View(await PaginatedList<Articles>.CreateAsync(model.AsNoTracking(), pageid ?? 1, 5));
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _context.Articles.FindAsync(id));
        }
    }
}
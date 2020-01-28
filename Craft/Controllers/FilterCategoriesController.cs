using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Craft.Data;
using Craft.Models;

namespace Craft.Controllers
{
    public class FilterCategoriesController : Controller
    {
        private readonly CraftMyPcContext _context;

        public FilterCategoriesController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: FilterCategories
        public async Task<IActionResult> Index()
        {
            var craftMyPcContext = _context.FilterCategories.Include(f => f.HardwareComponent);
            return View(await craftMyPcContext.ToListAsync());
        }

        // GET: FilterCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filterCategory = await _context.FilterCategories
                .Include(f => f.HardwareComponent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filterCategory == null)
            {
                return NotFound();
            }

            return View(filterCategory);
        }

        // GET: FilterCategories/Create
        public IActionResult Create()
        {
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "ID");
            return View();
        }

        // POST: FilterCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Active,HardwareComponentId")] FilterCategory filterCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filterCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "ID", filterCategory.HardwareComponentId);
            return View(filterCategory);
        }

        // GET: FilterCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filterCategory = await _context.FilterCategories.FindAsync(id);
            if (filterCategory == null)
            {
                return NotFound();
            }
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "ID", filterCategory.HardwareComponentId);
            return View(filterCategory);
        }

        // POST: FilterCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Active,HardwareComponentId")] FilterCategory filterCategory)
        {
            if (id != filterCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filterCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilterCategoryExists(filterCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "ID", filterCategory.HardwareComponentId);
            return View(filterCategory);
        }

        // GET: FilterCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filterCategory = await _context.FilterCategories
                .Include(f => f.HardwareComponent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filterCategory == null)
            {
                return NotFound();
            }

            return View(filterCategory);
        }

        // POST: FilterCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filterCategory = await _context.FilterCategories.FindAsync(id);
            _context.FilterCategories.Remove(filterCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilterCategoryExists(int id)
        {
            return _context.FilterCategories.Any(e => e.Id == id);
        }
    }
}

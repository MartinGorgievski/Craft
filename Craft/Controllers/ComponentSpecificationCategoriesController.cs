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
    public class ComponentSpecificationCategoriesController : Controller
    {
        private readonly CraftMyPcContext _context;

        public ComponentSpecificationCategoriesController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: ComponentSpecificationCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.ComponentSpecificationCategories.ToListAsync());
        }

        // GET: ComponentSpecificationCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentSpecificationCategory = await _context.ComponentSpecificationCategories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (componentSpecificationCategory == null)
            {
                return NotFound();
            }

            return View(componentSpecificationCategory);
        }

        // GET: ComponentSpecificationCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComponentSpecificationCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] ComponentSpecificationCategory componentSpecificationCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componentSpecificationCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(componentSpecificationCategory);
        }

        // GET: ComponentSpecificationCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentSpecificationCategory = await _context.ComponentSpecificationCategories.FindAsync(id);
            if (componentSpecificationCategory == null)
            {
                return NotFound();
            }
            return View(componentSpecificationCategory);
        }

        // POST: ComponentSpecificationCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] ComponentSpecificationCategory componentSpecificationCategory)
        {
            if (id != componentSpecificationCategory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componentSpecificationCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentSpecificationCategoryExists(componentSpecificationCategory.ID))
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
            return View(componentSpecificationCategory);
        }

        // GET: ComponentSpecificationCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentSpecificationCategory = await _context.ComponentSpecificationCategories
                .FirstOrDefaultAsync(m => m.ID == id);
            if (componentSpecificationCategory == null)
            {
                return NotFound();
            }

            return View(componentSpecificationCategory);
        }

        // POST: ComponentSpecificationCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componentSpecificationCategory = await _context.ComponentSpecificationCategories.FindAsync(id);
            _context.ComponentSpecificationCategories.Remove(componentSpecificationCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentSpecificationCategoryExists(int id)
        {
            return _context.ComponentSpecificationCategories.Any(e => e.ID == id);
        }
    }
}

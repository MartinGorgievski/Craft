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
    public class FilterComponentsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public FilterComponentsController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: FilterComponents
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilterComponents.ToListAsync());
        }

        // GET: FilterComponents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filterComponent = await _context.FilterComponents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filterComponent == null)
            {
                return NotFound();
            }

            return View(filterComponent);
        }

        // GET: FilterComponents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilterComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] FilterComponent filterComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filterComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(filterComponent);
        }

        // GET: FilterComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filterComponent = await _context.FilterComponents.FindAsync(id);
            if (filterComponent == null)
            {
                return NotFound();
            }
            return View(filterComponent);
        }

        // POST: FilterComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] FilterComponent filterComponent)
        {
            if (id != filterComponent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filterComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilterComponentExists(filterComponent.ID))
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
            return View(filterComponent);
        }

        // GET: FilterComponents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filterComponent = await _context.FilterComponents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (filterComponent == null)
            {
                return NotFound();
            }

            return View(filterComponent);
        }

        // POST: FilterComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filterComponent = await _context.FilterComponents.FindAsync(id);
            _context.FilterComponents.Remove(filterComponent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilterComponentExists(int id)
        {
            return _context.FilterComponents.Any(e => e.ID == id);
        }
    }
}

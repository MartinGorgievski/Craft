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
    public class ComponentSpecificationsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public ComponentSpecificationsController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: ComponentSpecifications
        public async Task<IActionResult> Index()
        {
            var craftMyPcContext = _context.ComponentSpecifications.Include(c => c.ComponentSpecificationCategory).Include(c => c.HardwareComponent);
            return View(await craftMyPcContext.ToListAsync());
        }

        // GET: ComponentSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentSpecification = await _context.ComponentSpecifications
                .Include(c => c.ComponentSpecificationCategory)
                .Include(c => c.HardwareComponent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (componentSpecification == null)
            {
                return NotFound();
            }

            return View(componentSpecification);
        }

        // GET: ComponentSpecifications/Create
        public IActionResult Create()
        {
            ViewData["ComponentSpecificationCategoryId"] = new SelectList(_context.ComponentSpecificationCategories, "ID", "Name");
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name");
            return View();
        }

        // POST: ComponentSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AttributeName,DateAdded,Primary,HardwareComponentId,ComponentSpecificationCategoryId")] ComponentSpecification componentSpecification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(componentSpecification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComponentSpecificationCategoryId"] = new SelectList(_context.ComponentSpecificationCategories, "ID", "Name", componentSpecification.ComponentSpecificationCategoryId);
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name", componentSpecification.HardwareComponentId);
            return View(componentSpecification);
        }

        // GET: ComponentSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentSpecification = await _context.ComponentSpecifications.FindAsync(id);
            if (componentSpecification == null)
            {
                return NotFound();
            }
            ViewData["ComponentSpecificationCategoryId"] = new SelectList(_context.ComponentSpecificationCategories, "ID", "Name", componentSpecification.ComponentSpecificationCategoryId);
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name", componentSpecification.HardwareComponentId);
            return View(componentSpecification);
        }

        // POST: ComponentSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AttributeName,DateAdded,Primary,HardwareComponentId,ComponentSpecificationCategoryId")] ComponentSpecification componentSpecification)
        {
            if (id != componentSpecification.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(componentSpecification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComponentSpecificationExists(componentSpecification.ID))
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
            ViewData["ComponentSpecificationCategoryId"] = new SelectList(_context.ComponentSpecificationCategories, "ID", "Name", componentSpecification.ComponentSpecificationCategoryId);
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name", componentSpecification.HardwareComponentId);
            return View(componentSpecification);
        }

        // GET: ComponentSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var componentSpecification = await _context.ComponentSpecifications
                .Include(c => c.ComponentSpecificationCategory)
                .Include(c => c.HardwareComponent)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (componentSpecification == null)
            {
                return NotFound();
            }

            return View(componentSpecification);
        }

        // POST: ComponentSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var componentSpecification = await _context.ComponentSpecifications.FindAsync(id);
            _context.ComponentSpecifications.Remove(componentSpecification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComponentSpecificationExists(int id)
        {
            return _context.ComponentSpecifications.Any(e => e.ID == id);
        }
    }
}

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
    public class HardwareUnitSpecificationsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public HardwareUnitSpecificationsController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: HardwareUnitSpecifications
        public async Task<IActionResult> Index()
        {
            var craftMyPcContext = _context.HardwareUnitSpecification.Include(h => h.ComponentSpecification).Include(h => h.FilterComponent).Include(h => h.HardwareUnit);
            return View(await craftMyPcContext.ToListAsync());
        }

        // GET: HardwareUnitSpecifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareUnitSpecification = await _context.HardwareUnitSpecification
                .Include(h => h.ComponentSpecification)
                .Include(h => h.FilterComponent)
                .Include(h => h.HardwareUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardwareUnitSpecification == null)
            {
                return NotFound();
            }

            return View(hardwareUnitSpecification);
        }

        // GET: HardwareUnitSpecifications/Create
        public IActionResult Create()
        {
            ViewData["ComponentSpecificationId"] = new SelectList(_context.ComponentSpecifications, "ID", "ID");
            ViewData["FilterComponentId"] = new SelectList(_context.FilterComponents, "ID", "ID");
            ViewData["HardwareUnitId"] = new SelectList(_context.HardwareUnits, "Id", "Id");
            return View();
        }

        // POST: HardwareUnitSpecifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AttributeValue,ShortInfo,FilterComponentId,HardwareUnitId,ComponentSpecificationId")] HardwareUnitSpecification hardwareUnitSpecification)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardwareUnitSpecification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComponentSpecificationId"] = new SelectList(_context.ComponentSpecifications, "ID", "ID", hardwareUnitSpecification.ComponentSpecificationId);
            ViewData["FilterComponentId"] = new SelectList(_context.FilterComponents, "ID", "ID", hardwareUnitSpecification.FilterComponentId);
            ViewData["HardwareUnitId"] = new SelectList(_context.HardwareUnits, "Id", "Id", hardwareUnitSpecification.HardwareUnitId);
            return View(hardwareUnitSpecification);
        }

        // GET: HardwareUnitSpecifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareUnitSpecification = await _context.HardwareUnitSpecification.FindAsync(id);
            if (hardwareUnitSpecification == null)
            {
                return NotFound();
            }
            ViewData["ComponentSpecificationId"] = new SelectList(_context.ComponentSpecifications, "ID", "ID", hardwareUnitSpecification.ComponentSpecificationId);
            ViewData["FilterComponentId"] = new SelectList(_context.FilterComponents, "ID", "ID", hardwareUnitSpecification.FilterComponentId);
            ViewData["HardwareUnitId"] = new SelectList(_context.HardwareUnits, "Id", "Id", hardwareUnitSpecification.HardwareUnitId);
            return View(hardwareUnitSpecification);
        }

        // POST: HardwareUnitSpecifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AttributeValue,ShortInfo,FilterComponentId,HardwareUnitId,ComponentSpecificationId")] HardwareUnitSpecification hardwareUnitSpecification)
        {
            if (id != hardwareUnitSpecification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardwareUnitSpecification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareUnitSpecificationExists(hardwareUnitSpecification.Id))
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
            ViewData["ComponentSpecificationId"] = new SelectList(_context.ComponentSpecifications, "ID", "ID", hardwareUnitSpecification.ComponentSpecificationId);
            ViewData["FilterComponentId"] = new SelectList(_context.FilterComponents, "ID", "ID", hardwareUnitSpecification.FilterComponentId);
            ViewData["HardwareUnitId"] = new SelectList(_context.HardwareUnits, "Id", "Id", hardwareUnitSpecification.HardwareUnitId);
            return View(hardwareUnitSpecification);
        }

        // GET: HardwareUnitSpecifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareUnitSpecification = await _context.HardwareUnitSpecification
                .Include(h => h.ComponentSpecification)
                .Include(h => h.FilterComponent)
                .Include(h => h.HardwareUnit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardwareUnitSpecification == null)
            {
                return NotFound();
            }

            return View(hardwareUnitSpecification);
        }

        // POST: HardwareUnitSpecifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardwareUnitSpecification = await _context.HardwareUnitSpecification.FindAsync(id);
            _context.HardwareUnitSpecification.Remove(hardwareUnitSpecification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareUnitSpecificationExists(int id)
        {
            return _context.HardwareUnitSpecification.Any(e => e.Id == id);
        }
    }
}

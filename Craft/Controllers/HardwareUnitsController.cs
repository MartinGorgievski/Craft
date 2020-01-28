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
    public class HardwareUnitsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public HardwareUnitsController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: HardwareUnits
        public async Task<IActionResult> Index()
        {
            var craftMyPcContext = _context.HardwareUnits.Include(h => h.HardwareComponent);
            return View(await craftMyPcContext.ToListAsync());
        }

        // GET: HardwareUnits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareUnit = await _context.HardwareUnits
                .Include(h => h.HardwareComponent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardwareUnit == null)
            {
                return NotFound();
            }

            return View(hardwareUnit);
        }

        // GET: HardwareUnits/Create
        public IActionResult Create()
        {
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name");
            return View();
        }

        // POST: HardwareUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageName,Title,Active,UrlName,HardwareComponentId")] HardwareUnit hardwareUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardwareUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name", hardwareUnit.HardwareComponentId);
            return View(hardwareUnit);
        }

        // GET: HardwareUnits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareUnit = await _context.HardwareUnits.FindAsync(id);
            if (hardwareUnit == null)
            {
                return NotFound();
            }
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name", hardwareUnit.HardwareComponentId);
            return View(hardwareUnit);
        }

        // POST: HardwareUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageName,Title,Active,UrlName,HardwareComponentId")] HardwareUnit hardwareUnit)
        {
            if (id != hardwareUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardwareUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareUnitExists(hardwareUnit.Id))
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
            ViewData["HardwareComponentId"] = new SelectList(_context.HardwareComponents, "ID", "Name", hardwareUnit.HardwareComponentId);
            return View(hardwareUnit);
        }

        // GET: HardwareUnits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareUnit = await _context.HardwareUnits
                .Include(h => h.HardwareComponent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hardwareUnit == null)
            {
                return NotFound();
            }

            return View(hardwareUnit);
        }

        // POST: HardwareUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardwareUnit = await _context.HardwareUnits.FindAsync(id);
            _context.HardwareUnits.Remove(hardwareUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareUnitExists(int id)
        {
            return _context.HardwareUnits.Any(e => e.Id == id);
        }
    }
}

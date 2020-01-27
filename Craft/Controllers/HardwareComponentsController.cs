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
    public class HardwareComponentsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public HardwareComponentsController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: HardwareComponents
        public async Task<IActionResult> Index()
        {
            return View(await _context.HardwareComponents.ToListAsync());
        }

        // GET: HardwareComponents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareComponent = await _context.HardwareComponents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hardwareComponent == null)
            {
                return NotFound();
            }

            return View(hardwareComponent);
        }

        // GET: HardwareComponents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HardwareComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,DateAdded,DateModified")] HardwareComponent hardwareComponent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hardwareComponent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hardwareComponent);
        }

        // GET: HardwareComponents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareComponent = await _context.HardwareComponents.FindAsync(id);
            if (hardwareComponent == null)
            {
                return NotFound();
            }
            return View(hardwareComponent);
        }

        // POST: HardwareComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,DateAdded,DateModified")] HardwareComponent hardwareComponent)
        {
            if (id != hardwareComponent.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hardwareComponent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HardwareComponentExists(hardwareComponent.ID))
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
            return View(hardwareComponent);
        }

        // GET: HardwareComponents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hardwareComponent = await _context.HardwareComponents
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hardwareComponent == null)
            {
                return NotFound();
            }

            return View(hardwareComponent);
        }

        // POST: HardwareComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hardwareComponent = await _context.HardwareComponents.FindAsync(id);
            _context.HardwareComponents.Remove(hardwareComponent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HardwareComponentExists(int id)
        {
            return _context.HardwareComponents.Any(e => e.ID == id);
        }
    }
}

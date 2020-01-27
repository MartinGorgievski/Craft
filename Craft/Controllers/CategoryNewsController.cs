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
    public class CategoryNewsController : Controller
    {
        private readonly CraftMyPcContext _context;

        public CategoryNewsController(CraftMyPcContext context)
        {
            _context = context;
        }

        // GET: CategoryNews
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryNews.ToListAsync());
        }

        // GET: CategoryNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryNews = await _context.CategoryNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryNews == null)
            {
                return NotFound();
            }

            return View(categoryNews);
        }

        // GET: CategoryNews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryNews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameCategory,DateAdded")] CategoryNews categoryNews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryNews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryNews);
        }

        // GET: CategoryNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryNews = await _context.CategoryNews.FindAsync(id);
            if (categoryNews == null)
            {
                return NotFound();
            }
            return View(categoryNews);
        }

        // POST: CategoryNews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameCategory,DateAdded")] CategoryNews categoryNews)
        {
            if (id != categoryNews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryNews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryNewsExists(categoryNews.Id))
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
            return View(categoryNews);
        }

        // GET: CategoryNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryNews = await _context.CategoryNews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryNews == null)
            {
                return NotFound();
            }

            return View(categoryNews);
        }

        // POST: CategoryNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryNews = await _context.CategoryNews.FindAsync(id);
            _context.CategoryNews.Remove(categoryNews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryNewsExists(int id)
        {
            return _context.CategoryNews.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cse355.Data;
using cse355.Models;

namespace cse355.Controllers
{
    public class DepotsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepotsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Depots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Depot.ToListAsync());
        }

        // GET: Depots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depot = await _context.Depot
                .FirstOrDefaultAsync(m => m.DepotID == id);
            if (depot == null)
            {
                return NotFound();
            }

            return View(depot);
        }

        // GET: Depots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Depots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepotID,District")] Depot depot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(depot);
        }

        // GET: Depots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depot = await _context.Depot.FindAsync(id);
            if (depot == null)
            {
                return NotFound();
            }
            return View(depot);
        }

        // POST: Depots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepotID,District")] Depot depot)
        {
            if (id != depot.DepotID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepotExists(depot.DepotID))
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
            return View(depot);
        }

        // GET: Depots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depot = await _context.Depot
                .FirstOrDefaultAsync(m => m.DepotID == id);
            if (depot == null)
            {
                return NotFound();
            }

            return View(depot);
        }

        // POST: Depots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depot = await _context.Depot.FindAsync(id);
            if (depot != null)
            {
                _context.Depot.Remove(depot);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepotExists(int id)
        {
            return _context.Depot.Any(e => e.DepotID == id);
        }
    }
}

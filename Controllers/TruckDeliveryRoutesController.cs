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
    public class TruckDeliveryRoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TruckDeliveryRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TruckDeliveryRoutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TruckDeliveryRoutes.ToListAsync());
        }

        // GET: TruckDeliveryRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckDeliveryRoutes = await _context.TruckDeliveryRoutes
                .FirstOrDefaultAsync(m => m.DeliveryRouteID == id);
            if (truckDeliveryRoutes == null)
            {
                return NotFound();
            }

            return View(truckDeliveryRoutes);
        }

        // GET: TruckDeliveryRoutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TruckDeliveryRoutes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleID,DeliveryRouteID,DeliveryRoute")] TruckDeliveryRoutes truckDeliveryRoutes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truckDeliveryRoutes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(truckDeliveryRoutes);
        }

        // GET: TruckDeliveryRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckDeliveryRoutes = await _context.TruckDeliveryRoutes.FindAsync(id);
            if (truckDeliveryRoutes == null)
            {
                return NotFound();
            }
            return View(truckDeliveryRoutes);
        }

        // POST: TruckDeliveryRoutes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleID,DeliveryRouteID,DeliveryRoute")] TruckDeliveryRoutes truckDeliveryRoutes)
        {
            if (id != truckDeliveryRoutes.DeliveryRouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truckDeliveryRoutes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TruckDeliveryRoutesExists(truckDeliveryRoutes.DeliveryRouteID))
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
            return View(truckDeliveryRoutes);
        }

        // GET: TruckDeliveryRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var truckDeliveryRoutes = await _context.TruckDeliveryRoutes
                .FirstOrDefaultAsync(m => m.DeliveryRouteID == id);
            if (truckDeliveryRoutes == null)
            {
                return NotFound();
            }

            return View(truckDeliveryRoutes);
        }

        // POST: TruckDeliveryRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truckDeliveryRoutes = await _context.TruckDeliveryRoutes.FindAsync(id);
            if (truckDeliveryRoutes != null)
            {
                _context.TruckDeliveryRoutes.Remove(truckDeliveryRoutes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TruckDeliveryRoutesExists(int id)
        {
            return _context.TruckDeliveryRoutes.Any(e => e.DeliveryRouteID == id);
        }
    }
}

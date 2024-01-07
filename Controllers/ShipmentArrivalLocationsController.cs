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
    public class ShipmentArrivalLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipmentArrivalLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShipmentArrivalLocations
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShipmentArrivalLocations.ToListAsync());
        }

        // GET: ShipmentArrivalLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentArrivalLocations = await _context.ShipmentArrivalLocations
                .FirstOrDefaultAsync(m => m.ShipmentID == id);
            if (shipmentArrivalLocations == null)
            {
                return NotFound();
            }

            return View(shipmentArrivalLocations);
        }

        // GET: ShipmentArrivalLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShipmentArrivalLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShipmentID,ArrivalLocationID,ArrivalLocation")] ShipmentArrivalLocations shipmentArrivalLocations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shipmentArrivalLocations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shipmentArrivalLocations);
        }

        // GET: ShipmentArrivalLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentArrivalLocations = await _context.ShipmentArrivalLocations.FindAsync(id);
            if (shipmentArrivalLocations == null)
            {
                return NotFound();
            }
            return View(shipmentArrivalLocations);
        }

        // POST: ShipmentArrivalLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShipmentID,ArrivalLocationID,ArrivalLocation")] ShipmentArrivalLocations shipmentArrivalLocations)
        {
            if (id != shipmentArrivalLocations.ShipmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shipmentArrivalLocations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShipmentArrivalLocationsExists(shipmentArrivalLocations.ShipmentID))
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
            return View(shipmentArrivalLocations);
        }

        // GET: ShipmentArrivalLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shipmentArrivalLocations = await _context.ShipmentArrivalLocations
                .FirstOrDefaultAsync(m => m.ShipmentID == id);
            if (shipmentArrivalLocations == null)
            {
                return NotFound();
            }

            return View(shipmentArrivalLocations);
        }

        // POST: ShipmentArrivalLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shipmentArrivalLocations = await _context.ShipmentArrivalLocations.FindAsync(id);
            if (shipmentArrivalLocations != null)
            {
                _context.ShipmentArrivalLocations.Remove(shipmentArrivalLocations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShipmentArrivalLocationsExists(int id)
        {
            return _context.ShipmentArrivalLocations.Any(e => e.ShipmentID == id);
        }
    }
}

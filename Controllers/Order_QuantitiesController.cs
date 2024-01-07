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
    public class Order_QuantitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Order_QuantitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order_Quantities
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order_Quantities.ToListAsync());
        }

        // GET: Order_Quantities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Quantities = await _context.Order_Quantities
                .FirstOrDefaultAsync(m => m.QuantityID == id);
            if (order_Quantities == null)
            {
                return NotFound();
            }

            return View(order_Quantities);
        }

        // GET: Order_Quantities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_Quantities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuantityID,Quantity,OrderID")] Order_Quantities order_Quantities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_Quantities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order_Quantities);
        }

        // GET: Order_Quantities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Quantities = await _context.Order_Quantities.FindAsync(id);
            if (order_Quantities == null)
            {
                return NotFound();
            }
            return View(order_Quantities);
        }

        // POST: Order_Quantities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuantityID,Quantity,OrderID")] Order_Quantities order_Quantities)
        {
            if (id != order_Quantities.QuantityID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_Quantities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_QuantitiesExists(order_Quantities.QuantityID))
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
            return View(order_Quantities);
        }

        // GET: Order_Quantities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_Quantities = await _context.Order_Quantities
                .FirstOrDefaultAsync(m => m.QuantityID == id);
            if (order_Quantities == null)
            {
                return NotFound();
            }

            return View(order_Quantities);
        }

        // POST: Order_Quantities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_Quantities = await _context.Order_Quantities.FindAsync(id);
            if (order_Quantities != null)
            {
                _context.Order_Quantities.Remove(order_Quantities);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_QuantitiesExists(int id)
        {
            return _context.Order_Quantities.Any(e => e.QuantityID == id);
        }
    }
}

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
    public class Order_OrderedProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Order_OrderedProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order_OrderedProduct
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order_OrderedProduct.ToListAsync());
        }

        // GET: Order_OrderedProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_OrderedProduct = await _context.Order_OrderedProduct
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order_OrderedProduct == null)
            {
                return NotFound();
            }

            return View(order_OrderedProduct);
        }

        // GET: Order_OrderedProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Order_OrderedProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,OrderedProductID,OrderedProduct")] Order_OrderedProduct order_OrderedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order_OrderedProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order_OrderedProduct);
        }

        // GET: Order_OrderedProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_OrderedProduct = await _context.Order_OrderedProduct.FindAsync(id);
            if (order_OrderedProduct == null)
            {
                return NotFound();
            }
            return View(order_OrderedProduct);
        }

        // POST: Order_OrderedProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,OrderedProductID,OrderedProduct")] Order_OrderedProduct order_OrderedProduct)
        {
            if (id != order_OrderedProduct.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order_OrderedProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order_OrderedProductExists(order_OrderedProduct.OrderID))
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
            return View(order_OrderedProduct);
        }

        // GET: Order_OrderedProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order_OrderedProduct = await _context.Order_OrderedProduct
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order_OrderedProduct == null)
            {
                return NotFound();
            }

            return View(order_OrderedProduct);
        }

        // POST: Order_OrderedProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order_OrderedProduct = await _context.Order_OrderedProduct.FindAsync(id);
            if (order_OrderedProduct != null)
            {
                _context.Order_OrderedProduct.Remove(order_OrderedProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order_OrderedProductExists(int id)
        {
            return _context.Order_OrderedProduct.Any(e => e.OrderID == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobiFix.Data;

namespace MobiFix.Controllers
{
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sales.Include(s => s.Brand).Include(s => s.Customer).Include(s => s.PaidStatus).Include(s => s.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Brand)
                .Include(s => s.Customer)
                .Include(s => s.PaidStatus)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name");
            ViewData["PaidStatusId"] = new SelectList(_context.PaidStatuses, "Id", "Status");
            ViewData["FixStatusId"] = new SelectList(_context.FixStatuses, "Id", "Status");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brandid,Model,Color,Serial,Description,Issue,Price" +
            ",Cost,NetRevenue,Paid,Unpaid,CustomerId,PhoneNumber,Date,FixStatusId,PaidStatusId,Notes")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Name", sale.Brandid);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", sale.CustomerId);
            ViewData["PaidStatusId"] = new SelectList(_context.PaidStatuses, "Id", "Status", sale.PaidStatusId);
            ViewData["FixStatusId"] = new SelectList(_context.FixStatuses, "Id", "Status", sale.FixStatusId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Name", sale.Brandid);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", sale.CustomerId);
            ViewData["PaidStatusId"] = new SelectList(_context.PaidStatuses, "Id", "Status", sale.PaidStatusId);
            ViewData["FixStatusId"] = new SelectList(_context.FixStatuses, "Id", "Status", sale.FixStatusId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brandid,Model,Color,Serial,Description,Issue,Price,Cost,NetRevenue,Paid,Unpaid,CustomerId,PhoneNumber,Date,FixStatusId,PaidStatusId,Notes")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
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
            ViewData["Brandid"] = new SelectList(_context.Brands, "Id", "Name", sale.Brandid);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Name", sale.CustomerId);
            ViewData["PaidStatusId"] = new SelectList(_context.PaidStatuses, "Id", "Status", sale.PaidStatusId);
            ViewData["FixStatusId"] = new SelectList(_context.FixStatuses, "Id", "Status", sale.FixStatusId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sales == null)
            {
                return NotFound();
            }

            var sale = await _context.Sales
                .Include(s => s.Brand)
                .Include(s => s.Customer)
                .Include(s => s.PaidStatus)
                .Include(s => s.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sales == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sales'  is null.");
            }
            var sale = await _context.Sales.FindAsync(id);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.Id == id);
        }
    }
}

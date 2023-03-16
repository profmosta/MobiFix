using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobiFix.Data;

namespace MobiFix.Controllers
{
    public class PaidStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaidStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaidStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaidStatuses.ToListAsync());
        }

        // GET: PaidStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaidStatuses == null)
            {
                return NotFound();
            }

            var paidStatus = await _context.PaidStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paidStatus == null)
            {
                return NotFound();
            }

            return View(paidStatus);
        }

        // GET: PaidStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaidStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] PaidStatus paidStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paidStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paidStatus);
        }

        // GET: PaidStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaidStatuses == null)
            {
                return NotFound();
            }

            var paidStatus = await _context.PaidStatuses.FindAsync(id);
            if (paidStatus == null)
            {
                return NotFound();
            }
            return View(paidStatus);
        }

        // POST: PaidStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] PaidStatus paidStatus)
        {
            if (id != paidStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paidStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaidStatusExists(paidStatus.Id))
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
            return View(paidStatus);
        }

        // GET: PaidStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaidStatuses == null)
            {
                return NotFound();
            }

            var paidStatus = await _context.PaidStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paidStatus == null)
            {
                return NotFound();
            }

            return View(paidStatus);
        }

        // POST: PaidStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaidStatuses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PaidStatuses'  is null.");
            }
            var paidStatus = await _context.PaidStatuses.FindAsync(id);
            if (paidStatus != null)
            {
                _context.PaidStatuses.Remove(paidStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaidStatusExists(int id)
        {
            return _context.PaidStatuses.Any(e => e.Id == id);
        }
    }
}

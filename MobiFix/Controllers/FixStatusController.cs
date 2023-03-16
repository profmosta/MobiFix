using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobiFix.Data;

namespace MobiFix.Controllers
{
    public class FixStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FixStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FixStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.FixStatuses.ToListAsync());
        }

        // GET: FixStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FixStatuses == null)
            {
                return NotFound();
            }

            var fixStatus = await _context.FixStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fixStatus == null)
            {
                return NotFound();
            }

            return View(fixStatus);
        }

        // GET: FixStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FixStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] FixStatus fixStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fixStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fixStatus);
        }

        // GET: FixStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FixStatuses == null)
            {
                return NotFound();
            }

            var fixStatus = await _context.FixStatuses.FindAsync(id);
            if (fixStatus == null)
            {
                return NotFound();
            }
            return View(fixStatus);
        }

        // POST: FixStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] FixStatus fixStatus)
        {
            if (id != fixStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fixStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FixStatusExists(fixStatus.Id))
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
            return View(fixStatus);
        }

        // GET: FixStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FixStatuses == null)
            {
                return NotFound();
            }

            var fixStatus = await _context.FixStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fixStatus == null)
            {
                return NotFound();
            }

            return View(fixStatus);
        }

        // POST: FixStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FixStatuses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FixStatuses'  is null.");
            }
            var fixStatus = await _context.FixStatuses.FindAsync(id);
            if (fixStatus != null)
            {
                _context.FixStatuses.Remove(fixStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FixStatusExists(int id)
        {
            return _context.FixStatuses.Any(e => e.Id == id);
        }
    }
}

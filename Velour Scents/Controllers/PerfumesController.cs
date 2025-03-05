using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Velour_Scents.Data;
using Velour_Scents.Models;
using System.Threading.Tasks;
using System.Linq;

namespace Velour_Scents.Controllers
{
    public class PerfumesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PerfumesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Anyone Can View Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perfumes.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfumes.FirstOrDefaultAsync(m => m.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }

            return View(perfume);
        }

        // ✅ Only Admin Can Create Products
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Brand,FragranceNotes,Price,ImageUrl")] Perfume perfume)
        {
            if (ModelState.IsValid)
            {
                _context.Add(perfume);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(perfume);
        }

        // ✅ Only Admin Can Edit Products
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfumes.FindAsync(id);
            if (perfume == null)
            {
                return NotFound();
            }
            return View(perfume);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Brand,FragranceNotes,Price,ImageUrl")] Perfume perfume)
        {
            if (id != perfume.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(perfume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerfumeExists(perfume.Id))
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
            return View(perfume);
        }

        // ✅ Only Admin Can Delete Products
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var perfume = await _context.Perfumes.FirstOrDefaultAsync(m => m.Id == id);
            if (perfume == null)
            {
                return NotFound();
            }

            return View(perfume);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var perfume = await _context.Perfumes.FindAsync(id);
            if (perfume != null)
            {
                _context.Perfumes.Remove(perfume);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerfumeExists(int id)
        {
            return _context.Perfumes.Any(e => e.Id == id);
        }
    }
}

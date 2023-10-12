using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TripulacionGoingMerry.Models;

namespace TripulacionGoingMerry.Controllers
{
    public class TripulantController : Controller
    {
        private readonly NombreDeTuBaseDeDatosContext _context;

        public TripulantController(NombreDeTuBaseDeDatosContext context)
        {
            _context = context;
        }

        // GET: Tripulant
        public async Task<IActionResult> Index()
        {
              return _context.Tripulants != null ? 
                          View(await _context.Tripulants.ToListAsync()) :
                          Problem("Entity set 'NombreDeTuBaseDeDatosContext.Tripulants'  is null.");
        }

        // GET: Tripulant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tripulants == null)
            {
                return NotFound();
            }

            var tripulant = await _context.Tripulants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripulant == null)
            {
                return NotFound();
            }

            return View(tripulant);
        }

        // GET: Tripulant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tripulant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,EnrollmentDate")] Tripulant tripulant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tripulant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tripulant);
        }

        // GET: Tripulant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tripulants == null)
            {
                return NotFound();
            }

            var tripulant = await _context.Tripulants.FindAsync(id);
            if (tripulant == null)
            {
                return NotFound();
            }
            return View(tripulant);
        }

        // POST: Tripulant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,EnrollmentDate")] Tripulant tripulant)
        {
            if (id != tripulant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tripulant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripulantExists(tripulant.Id))
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
            return View(tripulant);
        }

        // GET: Tripulant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tripulants == null)
            {
                return NotFound();
            }

            var tripulant = await _context.Tripulants
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tripulant == null)
            {
                return NotFound();
            }

            return View(tripulant);
        }

        // POST: Tripulant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tripulants == null)
            {
                return Problem("Entity set 'NombreDeTuBaseDeDatosContext.Tripulants'  is null.");
            }
            var tripulant = await _context.Tripulants.FindAsync(id);
            if (tripulant != null)
            {
                _context.Tripulants.Remove(tripulant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripulantExists(int id)
        {
          return (_context.Tripulants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

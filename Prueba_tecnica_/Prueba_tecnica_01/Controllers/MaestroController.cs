using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_01.Models;

namespace Prueba_tecnica_01.Controllers
{
    public class MaestroController : Controller
    {
        private readonly Colegio_prueba_tecnicaContext _context;

        public MaestroController(Colegio_prueba_tecnicaContext context)
        {
            _context = context;
        }

        // GET: Maestro
        public async Task<IActionResult> Index()
        {
              return _context.Maestros != null ? 
                          View(await _context.Maestros.ToListAsync()) :
                          Problem("Entity set 'Colegio_prueba_tecnicaContext.Maestros'  is null.");
        }

        // GET: Maestro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maestro == null)
            {
                return NotFound();
            }

            return View(maestro);
        }

        // GET: Maestro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maestro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido")] Maestro maestro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maestro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maestro);
        }

        // GET: Maestro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros.FindAsync(id);
            if (maestro == null)
            {
                return NotFound();
            }
            return View(maestro);
        }

        // POST: Maestro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido")] Maestro maestro)
        {
            if (id != maestro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maestro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaestroExists(maestro.Id))
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
            return View(maestro);
        }

        // GET: Maestro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Maestros == null)
            {
                return NotFound();
            }

            var maestro = await _context.Maestros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maestro == null)
            {
                return NotFound();
            }

            return View(maestro);
        }

        // POST: Maestro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Maestros == null)
            {
                return Problem("Entity set 'Colegio_prueba_tecnicaContext.Maestros'  is null.");
            }
            var maestro = await _context.Maestros.FindAsync(id);
            if (maestro != null)
            {
                _context.Maestros.Remove(maestro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaestroExists(int id)
        {
          return (_context.Maestros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba_tecnica_01.Extensions;
using Prueba_tecnica_01.Models;

namespace Prueba_tecnica_01.Controllers
{
    public class MateriaController : BaseController
    {
        private readonly Colegio_prueba_tecnicaContext _context;

        public MateriaController(Colegio_prueba_tecnicaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var colegio_prueba_tecnicaContext = _context.Materias.Include(m => m.IdProfesorNavigation);
            return View(await colegio_prueba_tecnicaContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        public IActionResult Create()
        {
            ViewData["IdProfesor"] = new SelectList(_context.Maestros, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreMateria,IdProfesor")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                basicNotification("Materia agregada correctamente!", notificationType.Success);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProfesor"] = new SelectList(_context.Maestros, "Id", "Id", materia.IdProfesor);
            return View(materia);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["IdProfesor"] = new SelectList(_context.Maestros, "Id", "Nombre", materia.IdProfesor);
            return View(materia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreMateria,IdProfesor")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                basicNotification("Materia actualizada correctamente!", notificationType.Success);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProfesor"] = new SelectList(_context.Maestros, "Id", "Nombre", materia.IdProfesor);
            return View(materia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materias == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.IdProfesorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materias == null)
            {
                return Problem("Entity set 'Colegio_prueba_tecnicaContext.Materias'  is null.");
            }
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
            }
            
            await _context.SaveChangesAsync();
            basicNotification("Materia eliminada correctamente!", notificationType.Success);
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
          return (_context.Materias?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

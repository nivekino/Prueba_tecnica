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
    public class MateriasxAlumnoController : BaseController
    {
        private readonly Colegio_prueba_tecnicaContext _context;

        public MateriasxAlumnoController(Colegio_prueba_tecnicaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var colegio_prueba_tecnicaContext = _context.MateriasxAlumnos.Include(m => m.IdAlumnoNavigation).Include(m => m.IdMateriaNavigation);
            return View(await colegio_prueba_tecnicaContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MateriasxAlumnos == null)
            {
                return NotFound();
            }

            var materiasxAlumno = await _context.MateriasxAlumnos
                .Include(m => m.IdAlumnoNavigation)
                .Include(m => m.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiasxAlumno == null)
            {
                return NotFound();
            }

            return View(materiasxAlumno);
        }

        public IActionResult Create()
        {
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre");
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "NombreMateria");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdMateria,IdAlumno,Calificacion1,Calificacion2,Calificacion3")] MateriasxAlumno materiasxAlumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materiasxAlumno);
                await _context.SaveChangesAsync();
                basicNotification("Calificación agregada correctamente!", notificationType.Success);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Id", materiasxAlumno.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "Id", materiasxAlumno.IdMateria);
            return View(materiasxAlumno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MateriasxAlumnos == null)
            {
                return NotFound();
            }

            var materiasxAlumno = await _context.MateriasxAlumnos.FindAsync(id);
            if (materiasxAlumno == null)
            {
                return NotFound();
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre", materiasxAlumno.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "NombreMateria", materiasxAlumno.IdMateria);
            return View(materiasxAlumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdMateria,IdAlumno,Calificacion1,Calificacion2,Calificacion3")] MateriasxAlumno materiasxAlumno)
        {
            if (id != materiasxAlumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materiasxAlumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriasxAlumnoExists(materiasxAlumno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                basicNotification("Calificación actualizada correctamente!", notificationType.Success);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAlumno"] = new SelectList(_context.Alumnos, "Id", "Nombre", materiasxAlumno.IdAlumno);
            ViewData["IdMateria"] = new SelectList(_context.Materias, "Id", "NombreMateria", materiasxAlumno.IdMateria);
            return View(materiasxAlumno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MateriasxAlumnos == null)
            {
                return NotFound();
            }

            var materiasxAlumno = await _context.MateriasxAlumnos
                .Include(m => m.IdAlumnoNavigation)
                .Include(m => m.IdMateriaNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materiasxAlumno == null)
            {
                return NotFound();
            }

            return View(materiasxAlumno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MateriasxAlumnos == null)
            {
                return Problem("Entity set 'Colegio_prueba_tecnicaContext.MateriasxAlumnos'  is null.");
            }
            var materiasxAlumno = await _context.MateriasxAlumnos.FindAsync(id);
            if (materiasxAlumno != null)
            {
                _context.MateriasxAlumnos.Remove(materiasxAlumno);
            }
            
            await _context.SaveChangesAsync();
            basicNotification("Calificación eliminada correctamente!", notificationType.Success);
            return RedirectToAction(nameof(Index));
        }

        private bool MateriasxAlumnoExists(int id)
        {
          return (_context.MateriasxAlumnos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

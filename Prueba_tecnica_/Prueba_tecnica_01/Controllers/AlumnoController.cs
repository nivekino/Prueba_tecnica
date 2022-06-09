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
    public class AlumnoController : BaseController
    {
        private readonly Colegio_prueba_tecnicaContext _context;

        public AlumnoController(Colegio_prueba_tecnicaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            
              return _context.Alumnos != null ? 
                          View(await _context.Alumnos.ToListAsync()) :
                          Problem("Entity set 'Colegio_prueba_tecnicaContext.Alumnos'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                basicNotification("Alumno agregado correctamente!", notificationType.Success);
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido")] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoExists(alumno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                basicNotification("Alumno actualizado correctamente!", notificationType.Success);
                return RedirectToAction(nameof(Index));
            }
            return View(alumno);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Alumnos == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Alumnos == null)
            {
                return Problem("Entity set 'Colegio_prueba_tecnicaContext.Alumnos'  is null.");
            }
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
            }
            
            await _context.SaveChangesAsync();
            basicNotification("Alumno eliminado correctamente!", notificationType.Success);
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
          return (_context.Alumnos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

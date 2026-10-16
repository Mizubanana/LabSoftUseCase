using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTask.Models;

namespace AppTask.Controllers
{
    public class IncidentesController : Controller
    {
        private readonly DbTasksContext _context;

        public IncidentesController(DbTasksContext context)
        {
            _context = context;
        }

        // GET: Incidentes
        public async Task<IActionResult> Index()
        {
              return _context.Incidente != null ? 
                          View(await _context.Incidente.ToListAsync()) :
                          Problem("Entity set 'DbTasksContext.Incidente'  is null.");
        }

        // GET: Incidentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Incidente == null)
            {
                return NotFound();
            }

            var incidente = await _context.Incidente
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (incidente == null)
            {
                return NotFound();
            }

            return View(incidente);
        }

        // GET: Incidentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incidentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("codigo,DescricaoProblema,DataIncidente,Solucao,Resolvido")] Incidente incidente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidente);
        }

        // GET: Incidentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Incidente == null)
            {
                return NotFound();
            }

            var incidente = await _context.Incidente.FindAsync(id);
            if (incidente == null)
            {
                return NotFound();
            }
            return View(incidente);
        }

        // POST: Incidentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("codigo,DescricaoProblema,DataIncidente,Solucao,Resolvido")] Incidente incidente)
        {
            if (id != incidente.codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidenteExists(incidente.codigo))
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
            return View(incidente);
        }

        // GET: Incidentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Incidente == null)
            {
                return NotFound();
            }

            var incidente = await _context.Incidente
                .FirstOrDefaultAsync(m => m.codigo == id);
            if (incidente == null)
            {
                return NotFound();
            }

            return View(incidente);
        }

        // POST: Incidentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Incidente == null)
            {
                return Problem("Entity set 'DbTasksContext.Incidente'  is null.");
            }
            var incidente = await _context.Incidente.FindAsync(id);
            if (incidente != null)
            {
                _context.Incidente.Remove(incidente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidenteExists(int id)
        {
          return (_context.Incidente?.Any(e => e.codigo == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICBF_3.Models;

namespace ICBF_3.Controllers
{
    public class AvancesAcademicoesController : Controller
    {
        private readonly IcbfContext _context;

        public AvancesAcademicoesController(IcbfContext context)
        {
            _context = context;
        }

        // GET: AvancesAcademicoes
        public async Task<IActionResult> Index()
        {
            var icbfContext = _context.AvancesAcademicos.Include(a => a.FkIdNinoNavigation);
            return View(await icbfContext.ToListAsync());
        }

        // GET: AvancesAcademicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avancesAcademico = await _context.AvancesAcademicos
                .Include(a => a.FkIdNinoNavigation)
                .FirstOrDefaultAsync(m => m.PkIdAvance == id);
            if (avancesAcademico == null)
            {
                return NotFound();
            }

            return View(avancesAcademico);
        }

        // GET: AvancesAcademicoes/Create
        public IActionResult Create()
        {
            ViewData["FkIdNino"] = new SelectList(_context.Ninos, "PkIdNino", "PkIdNino");
            return View();
        }

        // POST: AvancesAcademicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIdAvance,FechaNota,Descripcion,AnoEscolar,Nivel,Notas,FkIdNino")] AvancesAcademico avancesAcademico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avancesAcademico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdNino"] = new SelectList(_context.Ninos, "PkIdNino", "PkIdNino", avancesAcademico.FkIdNino);
            return View(avancesAcademico);
        }

        // GET: AvancesAcademicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avancesAcademico = await _context.AvancesAcademicos.FindAsync(id);
            if (avancesAcademico == null)
            {
                return NotFound();
            }
            ViewData["FkIdNino"] = new SelectList(_context.Ninos, "PkIdNino", "PkIdNino", avancesAcademico.FkIdNino);
            return View(avancesAcademico);
        }

        // POST: AvancesAcademicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIdAvance,FechaNota,Descripcion,AnoEscolar,Nivel,Notas,FkIdNino")] AvancesAcademico avancesAcademico)
        {
            if (id != avancesAcademico.PkIdAvance)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avancesAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvancesAcademicoExists(avancesAcademico.PkIdAvance))
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
            ViewData["FkIdNino"] = new SelectList(_context.Ninos, "PkIdNino", "PkIdNino", avancesAcademico.FkIdNino);
            return View(avancesAcademico);
        }

        // GET: AvancesAcademicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avancesAcademico = await _context.AvancesAcademicos
                .Include(a => a.FkIdNinoNavigation)
                .FirstOrDefaultAsync(m => m.PkIdAvance == id);
            if (avancesAcademico == null)
            {
                return NotFound();
            }

            return View(avancesAcademico);
        }

        // POST: AvancesAcademicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var avancesAcademico = await _context.AvancesAcademicos.FindAsync(id);
            if (avancesAcademico != null)
            {
                _context.AvancesAcademicos.Remove(avancesAcademico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvancesAcademicoExists(int id)
        {
            return _context.AvancesAcademicos.Any(e => e.PkIdAvance == id);
        }
    }
}

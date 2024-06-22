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
    public class NinoesController : Controller
    {
        private readonly IcbfContext _context;

        public NinoesController(IcbfContext context)
        {
            _context = context;
        }

        // GET: Ninoes
        public async Task<IActionResult> Index()
        {
            var icbfContext = _context.Ninos.Include(n => n.FkIdEpsNavigation).Include(n => n.FkIdJardinNavigation).Include(n => n.FkIdUsuarioNavigation);
            return View(await icbfContext.ToListAsync());
        }

        // GET: Ninoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos
                .Include(n => n.FkIdEpsNavigation)
                .Include(n => n.FkIdJardinNavigation)
                .Include(n => n.FkIdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.PkIdNino == id);
            if (nino == null)
            {
                return NotFound();
            }

            return View(nino);
        }

        // GET: Ninoes/Create
        public IActionResult Create()
        {
            ViewData["FkIdEps"] = new SelectList(_context.Eps, "PkIdEps", "nombre");
            ViewData["FkIdJardin"] = new SelectList(_context.Jardines, "PkIdJardin", "PkIdJardin");
            ViewData["FkIdUsuario"] = new SelectList(_context.Usuarios, "PkIdUsuario", "PkIdUsuario");
            return View();
        }

        // POST: Ninoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIdNino,Niup,TipoSangre,CiudadNacimiento,FkIdEps,FkIdJardin,FkIdUsuario")] Nino nino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdEps"] = new SelectList(_context.Eps, "PkIdEps", "nombre", nino.FkIdEps);
            ViewData["FkIdJardin"] = new SelectList(_context.Jardines, "PkIdJardin", "PkIdJardin", nino.FkIdJardin);
            ViewData["FkIdUsuario"] = new SelectList(_context.Usuarios, "PkIdUsuario", "PkIdUsuario", nino.FkIdUsuario);
            return View(nino);
        }

        // GET: Ninoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos.FindAsync(id);
            if (nino == null)
            {
                return NotFound();
            }
            ViewData["FkIdEps"] = new SelectList(_context.Eps, "PkIdEps", "PkIdEps", nino.FkIdEps);
            ViewData["FkIdJardin"] = new SelectList(_context.Jardines, "PkIdJardin", "PkIdJardin", nino.FkIdJardin);
            ViewData["FkIdUsuario"] = new SelectList(_context.Usuarios, "PkIdUsuario", "PkIdUsuario", nino.FkIdUsuario);
            return View(nino);
        }

        // POST: Ninoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIdNino,Niup,TipoSangre,CiudadNacimiento,FkIdEps,FkIdJardin,FkIdUsuario")] Nino nino)
        {
            if (id != nino.PkIdNino)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NinoExists(nino.PkIdNino))
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
            ViewData["FkIdEps"] = new SelectList(_context.Eps, "PkIdEps", "PkIdEps", nino.FkIdEps);
            ViewData["FkIdJardin"] = new SelectList(_context.Jardines, "PkIdJardin", "PkIdJardin", nino.FkIdJardin);
            ViewData["FkIdUsuario"] = new SelectList(_context.Usuarios, "PkIdUsuario", "PkIdUsuario", nino.FkIdUsuario);
            return View(nino);
        }

        // GET: Ninoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nino = await _context.Ninos
                .Include(n => n.FkIdEpsNavigation)
                .Include(n => n.FkIdJardinNavigation)
                .Include(n => n.FkIdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.PkIdNino == id);
            if (nino == null)
            {
                return NotFound();
            }

            return View(nino);
        }

        // POST: Ninoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nino = await _context.Ninos.FindAsync(id);
            if (nino != null)
            {
                _context.Ninos.Remove(nino);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NinoExists(int id)
        {
            return _context.Ninos.Any(e => e.PkIdNino == id);
        }
    }
}

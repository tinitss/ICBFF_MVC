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
    public class EpsController : Controller
    {
        private readonly IcbfContext _context;

        public EpsController(IcbfContext context)
        {
            _context = context;
        }

        // GET: Eps
        public async Task<IActionResult> Index()
        {
            return View(await _context.Eps.ToListAsync());
        }

        // GET: Eps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ep = await _context.Eps
                .FirstOrDefaultAsync(m => m.PkIdEps == id);
            if (ep == null)
            {
                return NotFound();
            }

            return View(ep);
        }

        // GET: Eps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Eps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIdEps,Nit,Nombre,CentroMedico,Direccion,Telefono")] Ep ep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ep);
        }

        // GET: Eps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ep = await _context.Eps.FindAsync(id);
            if (ep == null)
            {
                return NotFound();
            }
            return View(ep);
        }

        // POST: Eps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIdEps,Nit,Nombre,CentroMedico,Direccion,Telefono")] Ep ep)
        {
            if (id != ep.PkIdEps)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpExists(ep.PkIdEps))
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
            return View(ep);
        }

        // GET: Eps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ep = await _context.Eps
                .FirstOrDefaultAsync(m => m.PkIdEps == id);
            if (ep == null)
            {
                return NotFound();
            }

            return View(ep);
        }

        // POST: Eps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ep = await _context.Eps.FindAsync(id);
            if (ep != null)
            {
                _context.Eps.Remove(ep);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EpExists(int id)
        {
            return _context.Eps.Any(e => e.PkIdEps == id);
        }
    }
}

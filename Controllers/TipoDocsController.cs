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
    public class TipoDocsController : Controller
    {
        private readonly IcbfContext _context;

        public TipoDocsController(IcbfContext context)
        {
            _context = context;
        }

        // GET: TipoDocs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocs.ToListAsync());
        }

        // GET: TipoDocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDocs
                .FirstOrDefaultAsync(m => m.PkIdTipoDoc == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // GET: TipoDocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIdTipoDoc,Tipo")] TipoDoc tipoDoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDoc);
        }

        // GET: TipoDocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDocs.FindAsync(id);
            if (tipoDoc == null)
            {
                return NotFound();
            }
            return View(tipoDoc);
        }

        // POST: TipoDocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIdTipoDoc,Tipo")] TipoDoc tipoDoc)
        {
            if (id != tipoDoc.PkIdTipoDoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDocExists(tipoDoc.PkIdTipoDoc))
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
            return View(tipoDoc);
        }

        // GET: TipoDocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDoc = await _context.TipoDocs
                .FirstOrDefaultAsync(m => m.PkIdTipoDoc == id);
            if (tipoDoc == null)
            {
                return NotFound();
            }

            return View(tipoDoc);
        }

        // POST: TipoDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDoc = await _context.TipoDocs.FindAsync(id);
            if (tipoDoc != null)
            {
                _context.TipoDocs.Remove(tipoDoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDocExists(int id)
        {
            return _context.TipoDocs.Any(e => e.PkIdTipoDoc == id);
        }
    }
}

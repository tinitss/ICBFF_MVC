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
    public class JardinesController : Controller
    {
        private readonly IcbfContext _context;

        public JardinesController(IcbfContext context)
        {
            _context = context;
        }

        // GET: Jardines
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jardines.ToListAsync());
        }

        // GET: Jardines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardine = await _context.Jardines
                .FirstOrDefaultAsync(m => m.PkIdJardin == id);
            if (jardine == null)
            {
                return NotFound();
            }

            return View(jardine);
        }

        // GET: Jardines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jardines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIdJardin,Nombre,Direccion,Estado")] Jardine jardine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jardine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jardine);
        }

        // GET: Jardines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardine = await _context.Jardines.FindAsync(id);
            if (jardine == null)
            {
                return NotFound();
            }
            return View(jardine);
        }

        // POST: Jardines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIdJardin,Nombre,Direccion,Estado")] Jardine jardine)
        {
            if (id != jardine.PkIdJardin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jardine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JardineExists(jardine.PkIdJardin))
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
            return View(jardine);
        }

        // GET: Jardines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jardine = await _context.Jardines
                .FirstOrDefaultAsync(m => m.PkIdJardin == id);
            if (jardine == null)
            {
                return NotFound();
            }

            return View(jardine);
        }

        // POST: Jardines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jardine = await _context.Jardines.FindAsync(id);
            if (jardine != null)
            {
                _context.Jardines.Remove(jardine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JardineExists(int id)
        {
            return _context.Jardines.Any(e => e.PkIdJardin == id);
        }
    }
}

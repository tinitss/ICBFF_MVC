﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICBF_3.Models;

namespace ICBF_3.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IcbfContext _context;

        public UsuariosController(IcbfContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var icbfContext = _context.Usuarios.Include(u => u.FkIdRolNavigation).Include(u => u.FkIdTipoDocNavigation);
            return View(await icbfContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.FkIdRolNavigation)
                .Include(u => u.FkIdTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.PkIdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["FkIdRol"] = new SelectList(_context.Roles, "PkIdRol", "PkIdRol");
            ViewData["FkIdTipoDoc"] = new SelectList(_context.TipoDocs, "PkIdTipoDoc", "PkIdTipoDoc");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkIdUsuario,Identificacion,Nombre,FechaNacimiento,Telefono,Correo,Direccion,FkIdRol,FkIdTipoDoc")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkIdRol"] = new SelectList(_context.Roles, "PkIdRol", "PkIdRol", usuario.FkIdRol);
            ViewData["FkIdTipoDoc"] = new SelectList(_context.TipoDocs, "PkIdTipoDoc", "PkIdTipoDoc", usuario.FkIdTipoDoc);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["FkIdRol"] = new SelectList(_context.Roles, "PkIdRol", "PkIdRol", usuario.FkIdRol);
            ViewData["FkIdTipoDoc"] = new SelectList(_context.TipoDocs, "PkIdTipoDoc", "PkIdTipoDoc", usuario.FkIdTipoDoc);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIdUsuario,Identificacion,Nombre,FechaNacimiento,Telefono,Correo,Direccion,FkIdRol,FkIdTipoDoc")] Usuario usuario)
        {
            if (id != usuario.PkIdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.PkIdUsuario))
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
            ViewData["FkIdRol"] = new SelectList(_context.Roles, "PkIdRol", "PkIdRol", usuario.FkIdRol);
            ViewData["FkIdTipoDoc"] = new SelectList(_context.TipoDocs, "PkIdTipoDoc", "PkIdTipoDoc", usuario.FkIdTipoDoc);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.FkIdRolNavigation)
                .Include(u => u.FkIdTipoDocNavigation)
                .FirstOrDefaultAsync(m => m.PkIdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.PkIdUsuario == id);
        }
    }
}

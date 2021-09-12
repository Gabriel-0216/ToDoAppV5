using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoAppV5.Data;
using ToDoAppV5.Models;

namespace ToDoAppV5.Controllers
{
    public class RealizadoresController : Controller
    {
        private readonly BancoContexto _context;

        public RealizadoresController(BancoContexto context)
        {
            _context = context;
        }

        // GET: Realizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Realizadores.ToListAsync());
        }

        // GET: Realizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizador = await _context.Realizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realizador == null)
            {
                return NotFound();
            }

            return View(realizador);
        }

        // GET: Realizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Realizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeRealizador")] Realizador realizador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realizador);
        }

        // GET: Realizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizador = await _context.Realizadores.FindAsync(id);
            if (realizador == null)
            {
                return NotFound();
            }
            return View(realizador);
        }

        // POST: Realizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeRealizador")] Realizador realizador)
        {
            if (id != realizador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealizadorExists(realizador.Id))
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
            return View(realizador);
        }

        // GET: Realizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var realizador = await _context.Realizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realizador == null)
            {
                return NotFound();
            }

            return View(realizador);
        }

        // POST: Realizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var realizador = await _context.Realizadores.FindAsync(id);
            _context.Realizadores.Remove(realizador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RealizadorExists(int id)
        {
            return _context.Realizadores.Any(e => e.Id == id);
        }
    }
}

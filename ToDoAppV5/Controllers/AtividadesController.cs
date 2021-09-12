using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoAppV5.Data;
using ToDoAppV5.Models;
using ToDoAppV5.ViewModels;

namespace ToDoAppV5.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly BancoContexto _context;

        public AtividadesController(BancoContexto context)
        {
            _context = context;
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            AtividadeStatusRealizadorCategoriaViewModel vm = new AtividadeStatusRealizadorCategoriaViewModel();
            vm.CategoriasLista = _context.Categorias.ToList();
            vm.RealizadoresLista = _context.Realizadores.ToList();
            vm.StatusLista = _context.Status.ToList();
            vm.AtividadesLista = _context.Atividades.ToList();
            return View(vm);
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            AtividadeStatusRealizadorCategoriaViewModel vm = new AtividadeStatusRealizadorCategoriaViewModel();
            vm.CategoriasLista = _context.Categorias.ToList();
            vm.RealizadoresLista = _context.Realizadores.ToList();
            vm.StatusLista = _context.Status.ToList();

            return View(vm);
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeAtividade,IdCategoria,IdStatus,IdRealizador,DataRegistro")] Atividade atividade)
        {

            atividade.DataRegistro = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(atividade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atividade);
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }
           
            AtividadeStatusRealizadorCategoriaViewModel vm = new AtividadeStatusRealizadorCategoriaViewModel();
            vm.CategoriasLista = _context.Categorias.ToList();
            vm.RealizadoresLista = _context.Realizadores.ToList();
            vm.StatusLista = _context.Status.ToList();
            vm.DataRegistro = atividade.DataRegistro;
            vm.Id = atividade.Id;
            vm.IdCategoria = atividade.IdCategoria;
            vm.IdRealizador = atividade.IdRealizador;
            vm.IdStatus = atividade.IdStatus;
            vm.NomeAtividade = atividade.NomeAtividade;


            return View(vm);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeAtividade,IdCategoria,IdStatus,IdRealizador,DataRegistro")] Atividade atividade)
        {
            if (id != atividade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExists(atividade.Id))
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
            return View(atividade);
        }

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }

            return View(atividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividades.Any(e => e.Id == id);
        }
    }
}

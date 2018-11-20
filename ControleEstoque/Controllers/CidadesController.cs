using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleEstoque.Models.Data;
using ControleEstoque.Models.Entities;

namespace ControleEstoque.Controllers
{
    public class CidadesController : Controller
    {
        private readonly StockContext _context;

        public CidadesController(StockContext context)
        {
            _context = context;
        }

        // GET: Cidades
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.Cidades.Include(c => c.Estado).Include(c => c.Pais);
            return View(await stockContext.ToListAsync());
        }

        // GET: Cidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(m => m.CidadeID == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // GET: Cidades/Create
        public IActionResult Create()
        {
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID");
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID");
            return View();
        }

        // POST: Cidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CidadeID,Nome,Ativo,EstadoID,PaisID")] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cidade);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID", cidade.EstadoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID", cidade.PaisID);
            return View(cidade);
        }

        // GET: Cidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID", cidade.EstadoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID", cidade.PaisID);
            return View(cidade);
        }

        // POST: Cidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CidadeID,Nome,Ativo,EstadoID,PaisID")] Cidade cidade)
        {
            if (id != cidade.CidadeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CidadeExists(cidade.CidadeID))
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
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID", cidade.EstadoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID", cidade.PaisID);
            return View(cidade);
        }

        // GET: Cidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidade = await _context.Cidades
                .Include(c => c.Estado)
                .Include(c => c.Pais)
                .FirstOrDefaultAsync(m => m.CidadeID == id);
            if (cidade == null)
            {
                return NotFound();
            }

            return View(cidade);
        }

        // POST: Cidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cidade = await _context.Cidades.FindAsync(id);
            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CidadeExists(int id)
        {
            return _context.Cidades.Any(e => e.CidadeID == id);
        }
    }
}

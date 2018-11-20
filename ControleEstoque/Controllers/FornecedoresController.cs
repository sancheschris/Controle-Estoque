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
    public class FornecedoresController : Controller
    {
        private readonly StockContext _context;

        public FornecedoresController(StockContext context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            var stockContext = _context.Fornecedores.Include(f => f.Cidade).Include(f => f.Estado).Include(f => f.Pais);
            return View(await stockContext.ToListAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Cidade)
                .Include(f => f.Estado)
                .Include(f => f.Pais)
                .FirstOrDefaultAsync(m => m.FornecedorID == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Create()
        {
            ViewData["CidadeID"] = new SelectList(_context.Cidades, "CidadeID", "CidadeID");
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID");
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID");
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FornecedorID,Nome,CNPJ,Telefone,Logradouro,Numero,CEP,PaisID,EstadoID,CidadeID,Ativo")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeID"] = new SelectList(_context.Cidades, "CidadeID", "CidadeID", fornecedor.CidadeID);
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID", fornecedor.EstadoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID", fornecedor.PaisID);
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            ViewData["CidadeID"] = new SelectList(_context.Cidades, "CidadeID", "CidadeID", fornecedor.CidadeID);
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID", fornecedor.EstadoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID", fornecedor.PaisID);
            return View(fornecedor);
        }

        // POST: Fornecedors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FornecedorID,Nome,CNPJ,Telefone,Logradouro,Numero,CEP,PaisID,EstadoID,CidadeID,Ativo")] Fornecedor fornecedor)
        {
            if (id != fornecedor.FornecedorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.FornecedorID))
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
            ViewData["CidadeID"] = new SelectList(_context.Cidades, "CidadeID", "CidadeID", fornecedor.CidadeID);
            ViewData["EstadoID"] = new SelectList(_context.Estados, "EstadoID", "EstadoID", fornecedor.EstadoID);
            ViewData["PaisID"] = new SelectList(_context.Paises, "PaisID", "PaisID", fornecedor.PaisID);
            return View(fornecedor);
        }

        // GET: Fornecedors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Cidade)
                .Include(f => f.Estado)
                .Include(f => f.Pais)
                .FirstOrDefaultAsync(m => m.FornecedorID == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.FornecedorID == id);
        }
    }
}

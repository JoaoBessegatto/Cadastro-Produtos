using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro_Produtos.Data;
using Cadastro_Produtos.Models;

namespace Cadastro_Produtos.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly Context _context;

        public ProdutosController(Context context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
              return _context.Produtos != null ? 
                          View(await _context.Produtos.ToListAsync()) :
                          Problem("Entity set 'Context.Produtos'  is null.");
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtosModel = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            return View(produtosModel);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Quantidade,Preco,DataCadastro")] ProdutosModel produtosModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtosModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtosModel);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtosModel = await _context.Produtos.FindAsync(id);
            if (produtosModel == null)
            {
                return NotFound();
            }
            return View(produtosModel);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Quantidade,Preco,DataCadastro")] ProdutosModel produtosModel)
        {
            if (id != produtosModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosModelExists(produtosModel.Id))
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
            return View(produtosModel);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtosModel = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            return View(produtosModel);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'Context.Produtos'  is null.");
            }
            var produtosModel = await _context.Produtos.FindAsync(id);
            if (produtosModel != null)
            {
                _context.Produtos.Remove(produtosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosModelExists(int id)
        {
          return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

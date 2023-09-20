using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gerenciador_de_Notas_Fiscais.Data;
using Gerenciador_de_Notas_Fiscais.Models;
using AutoMapper;
using Gerenciador_de_Notas_Fiscais.ViewModel;

namespace Gerenciador_de_Notas_Fiscais.Controllers
{
    public class NotaFiscalsController : Controller
    {
        private readonly NotaFiscalContext _context;

        public NotaFiscalsController(NotaFiscalContext context)
        {
            _context = context;
        }

        // GET: NotaFiscals
        public async Task<IActionResult> Index()
        {
            if (_context.NotaFiscal == null)
                Problem("Entity set 'NotaFiscalContext.NotaFiscal'  is null.");

            var notaFiscalList = await _context.NotaFiscal.ToListAsync();

            List<NotaFiscalViewModel> notaFiscalViewModels;

           // TODO: Falta terminar o mapeamento para a NotaFiscalViewModel

            return View(notaFiscalList);
        }

        // GET: NotaFiscals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NotaFiscals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NotaFiscal notaFiscal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaFiscal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notaFiscal);
        }

        // GET: NotaFiscals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NotaFiscal == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            if (notaFiscal == null)
            {
                return NotFound();
            }
            return View(notaFiscal);
        }

        // POST: NotaFiscals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNota,Emissor,Data")] NotaFiscal notaFiscal)
        {
            if (id != notaFiscal.IdNota)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaFiscal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaFiscalExists(notaFiscal.IdNota))
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
            return View(notaFiscal);
        }

        // GET: NotaFiscals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NotaFiscal == null)
            {
                return NotFound();
            }

            var notaFiscal = await _context.NotaFiscal
                .FirstOrDefaultAsync(m => m.IdNota == id);
            if (notaFiscal == null)
            {
                return NotFound();
            }

            return View(notaFiscal);
        }

        // POST: NotaFiscals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NotaFiscal == null)
            {
                return Problem("Entity set 'NotaFiscalContext.NotaFiscal'  is null.");
            }
            var notaFiscal = await _context.NotaFiscal.FindAsync(id);
            if (notaFiscal != null)
            {
                _context.NotaFiscal.Remove(notaFiscal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaFiscalExists(int id)
        {
          return (_context.NotaFiscal?.Any(e => e.IdNota == id)).GetValueOrDefault();
        }
    }
}

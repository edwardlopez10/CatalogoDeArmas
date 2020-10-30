using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CatalogoDeArmas.Models;

namespace CatalogoDeArmas.Controllers
{
    public class ArmasController : Controller
    {
        private readonly ArmaContext _context;

        public ArmasController(ArmaContext context)
        {
            _context = context;
        }

        // GET: Armas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Armas.ToListAsync());
        }

        // GET: Armas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Armas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arma == null)
            {
                return NotFound();
            }

            return View(arma);
        }

        // GET: Armas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Armas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Img")] Arma arma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arma);
        }

        // GET: Armas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Armas.FindAsync(id);
            if (arma == null)
            {
                return NotFound();
            }
            return View(arma);
        }

        // POST: Armas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Img")] Arma arma)
        {
            if (id != arma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArmaExists(arma.Id))
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
            return View(arma);
        }

        // GET: Armas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arma = await _context.Armas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (arma == null)
            {
                return NotFound();
            }

            return View(arma);
        }

        // POST: Armas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arma = await _context.Armas.FindAsync(id);
            _context.Armas.Remove(arma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArmaExists(int id)
        {
            return _context.Armas.Any(e => e.Id == id);
        }
    }
}

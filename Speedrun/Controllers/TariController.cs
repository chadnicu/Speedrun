using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Speedrun.Data;
using Speedrun.Models;

namespace Speedrun.Controllers
{
    public class TariController : Controller
    {
        private readonly Context _context;

        public TariController(Context context)
        {
            _context = context;
        }

        // GET: Tari
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tari.ToListAsync());
        }

        // GET: Tari/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tara = await _context.Tari
                .FirstOrDefaultAsync(m => m.CodTara == id);
            if (tara == null)
            {
                return NotFound();
            }

            return View(tara);
        }

        // GET: Tari/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tari/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodTara,Denumire,Continent")] Tara tara)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tara);
        }

        // GET: Tari/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tara = await _context.Tari.FindAsync(id);
            if (tara == null)
            {
                return NotFound();
            }
            return View(tara);
        }

        // POST: Tari/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodTara,Denumire,Continent")] Tara tara)
        {
            if (id != tara.CodTara)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tara);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaraExists(tara.CodTara))
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
            return View(tara);
        }

        // GET: Tari/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tara = await _context.Tari
                .FirstOrDefaultAsync(m => m.CodTara == id);
            if (tara == null)
            {
                return NotFound();
            }

            return View(tara);
        }

        // POST: Tari/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tara = await _context.Tari.FindAsync(id);
            if (tara != null)
            {
                _context.Tari.Remove(tara);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaraExists(int id)
        {
            return _context.Tari.Any(e => e.CodTara == id);
        }


        [HttpGet]
        public async Task<IActionResult> DupaContinent(string? continent)
        {
            var continente = await _context.Tari.Select(t => t.Continent).Distinct().ToListAsync();
            ViewBag.Continente = continente;
            
            if (continent == null) return View(new Tara[] {});

            var tari = await _context.Tari.Where(t => t.Continent == continent).ToListAsync();

            return View(tari);
        }

        [HttpGet]
        public async Task<IActionResult> TariCuNrOrase()
        {
            var tari = await _context.Tari.Include(t=>t.Orase).ToListAsync();

            return View(tari);
        }
    }
}

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
    public class OraseController : Controller
    {
        private readonly Context _context;

        public OraseController(Context context)
        {
            _context = context;
        }

        // GET: Orase
        public async Task<IActionResult> Index()
        {
            var context = _context.Orase.Include(o => o.Tara);
            return View(await context.ToListAsync());
        }

        // GET: Orase/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oras = await _context.Orase
                .Include(o => o.Tara)
                .FirstOrDefaultAsync(m => m.CodOras == id);
            if (oras == null)
            {
                return NotFound();
            }

            return View(oras);
        }

        // GET: Orase/Create
        public IActionResult Create()
        {
            ViewData["CodTara"] = new SelectList(_context.Tari, "CodTara", "Denumire");
            return View();
        }

        // POST: Orase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodOras,Denumire,NumarulLocuitori,CodTara")] Oras oras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodTara"] = new SelectList(_context.Tari, "CodTara", "Denumire", oras.CodTara);
            return View(oras);
        }

        // GET: Orase/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oras = await _context.Orase.FindAsync(id);
            if (oras == null)
            {
                return NotFound();
            }
            ViewData["CodTara"] = new SelectList(_context.Tari, "CodTara", "Denumire", oras.CodTara);
            return View(oras);
        }

        // POST: Orase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CodOras,Denumire,NumarulLocuitori,CodTara")] Oras oras)
        {
            if (id != oras.CodOras)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrasExists(oras.CodOras))
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
            ViewData["CodTara"] = new SelectList(_context.Tari, "CodTara", "Denumire", oras.CodTara);
            return View(oras);
        }

        // GET: Orase/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oras = await _context.Orase
                .Include(o => o.Tara)
                .FirstOrDefaultAsync(m => m.CodOras == id);
            if (oras == null)
            {
                return NotFound();
            }

            return View(oras);
        }

        // POST: Orase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oras = await _context.Orase.FindAsync(id);
            if (oras != null)
            {
                _context.Orase.Remove(oras);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrasExists(int id)
        {
            return _context.Orase.Any(e => e.CodOras == id);
        }

        [HttpGet]
        public async Task<IActionResult> PesteUnMilion()
        {
            var orase = await _context.Orase.Include(o => o.Tara).Where(o => o.NumarulLocuitori > 1000000).ToListAsync();
            return View(orase);
        }

    }
}

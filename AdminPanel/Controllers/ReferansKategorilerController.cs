using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminPanel.Entities;
using AdminPanel.Identity;

namespace AdminPanel.Controllers
{
    public class ReferansKategorilerController : Controller
    {
        private readonly AdminPanelContext _context;

        public ReferansKategorilerController(AdminPanelContext context)
        {
            _context = context;
        }

        // GET: ReferansKategoriler
        public async Task<IActionResult> Index()
        {
            var adminPanelContext = _context.ReferansKategoriler.Include(r => r.ReferansKategori);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: ReferansKategoriler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReferansKategoriler == null)
            {
                return NotFound();
            }

            var referansKategoriler = await _context.ReferansKategoriler
                .Include(r => r.ReferansKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referansKategoriler == null)
            {
                return NotFound();
            }

            return View(referansKategoriler);
        }

        // GET: ReferansKategoriler/Create
        public IActionResult Create()
        {
            ViewData["UstKategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: ReferansKategoriler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriAdi,Durum,UstKategoriId")] ReferansKategoriler referansKategoriler)
        {
            if (ModelState.IsValid)
            {




                _context.Add(referansKategoriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UstKategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi", referansKategoriler.UstKategoriId);
            return View(referansKategoriler);
        }

        // GET: ReferansKategoriler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReferansKategoriler == null)
            {
                return NotFound();
            }

            var referansKategoriler = await _context.ReferansKategoriler.FindAsync(id);
            if (referansKategoriler == null)
            {
                return NotFound();
            }
            ViewData["UstKategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi", referansKategoriler.UstKategoriId);
            return View(referansKategoriler);
        }

        // POST: ReferansKategoriler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriAdi,Durum,UstKategoriId")] ReferansKategoriler referansKategoriler)
        {
            if (id != referansKategoriler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referansKategoriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferansKategorilerExists(referansKategoriler.Id))
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
            ViewData["UstKategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi", referansKategoriler.UstKategoriId);
            return View(referansKategoriler);
        }

        // GET: ReferansKategoriler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReferansKategoriler == null)
            {
                return NotFound();
            }

            var referansKategoriler = await _context.ReferansKategoriler
                .Include(r => r.ReferansKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referansKategoriler == null)
            {
                return NotFound();
            }

            return View(referansKategoriler);
        }

        // POST: ReferansKategoriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReferansKategoriler == null)
            {
                return Problem("Entity set 'AdminPanelContext.ReferansKategoriler'  is null.");
            }
            var referansKategoriler = await _context.ReferansKategoriler.FindAsync(id);
            if (referansKategoriler != null)
            {
                _context.ReferansKategoriler.Remove(referansKategoriler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferansKategorilerExists(int id)
        {
          return (_context.ReferansKategoriler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

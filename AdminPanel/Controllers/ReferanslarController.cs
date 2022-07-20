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
    public class ReferanslarController : Controller
    {
        private readonly AdminPanelContext _context;

        public ReferanslarController(AdminPanelContext context)
        {
            _context = context;
        }

        // GET: Referanslar
        public async Task<IActionResult> Index()
        {
            var adminPanelContext = _context.Referanslar.Include(r => r.ReferansKategori);
            return View(await adminPanelContext.ToListAsync());
        }

        // GET: Referanslar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Referanslar == null)
            {
                return NotFound();
            }

            var referanslar = await _context.Referanslar
                .Include(r => r.ReferansKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referanslar == null)
            {
                return NotFound();
            }

            return View(referanslar);
        }

        // GET: Referanslar/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Referanslar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriId,Durum,Baslik,Resim,KisaAciklama,Icerik")] Referanslar referanslar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referanslar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi", referanslar.KategoriId);
            return View(referanslar);
        }

        // GET: Referanslar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Referanslar == null)
            {
                return NotFound();
            }

            var referanslar = await _context.Referanslar.FindAsync(id);
            if (referanslar == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi", referanslar.KategoriId);
            return View(referanslar);
        }

        // POST: Referanslar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriId,Durum,Baslik,Resim,KisaAciklama,Icerik")] Referanslar referanslar)
        {
            if (id != referanslar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referanslar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferanslarExists(referanslar.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.ReferansKategoriler, "Id", "KategoriAdi", referanslar.KategoriId);
            return View(referanslar);
        }

        // GET: Referanslar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Referanslar == null)
            {
                return NotFound();
            }

            var referanslar = await _context.Referanslar
                .Include(r => r.ReferansKategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referanslar == null)
            {
                return NotFound();
            }

            return View(referanslar);
        }

        // POST: Referanslar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Referanslar == null)
            {
                return Problem("Entity set 'AdminPanelContext.Referanslar'  is null.");
            }
            var referanslar = await _context.Referanslar.FindAsync(id);
            if (referanslar != null)
            {
                _context.Referanslar.Remove(referanslar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferanslarExists(int id)
        {
          return (_context.Referanslar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PTPMQL.Models;

namespace PTPMBTL.Controllers
{
    public class QuanLyHangGuiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyHangGuiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuanLyHangGui
        public async Task<IActionResult> Index()
        {
              return _context.QuanLiHangGui != null ? 
                          View(await _context.QuanLiHangGui.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuanLiHangGui'  is null.");
        }

        // GET: QuanLyHangGui/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.QuanLiHangGui == null)
            {
                return NotFound();
            }

            var quanLiHangGui = await _context.QuanLiHangGui
                .FirstOrDefaultAsync(m => m.MaHangGui == id);
            if (quanLiHangGui == null)
            {
                return NotFound();
            }

            return View(quanLiHangGui);
        }

        // GET: QuanLyHangGui/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLyHangGui/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHangGui,NgayGioGuiHang,TrongLuongHangGui,XacNhanHopLe")] QuanLiHangGui quanLiHangGui)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLiHangGui);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanLiHangGui);
        }

        // GET: QuanLyHangGui/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.QuanLiHangGui == null)
            {
                return NotFound();
            }

            var quanLiHangGui = await _context.QuanLiHangGui.FindAsync(id);
            if (quanLiHangGui == null)
            {
                return NotFound();
            }
            return View(quanLiHangGui);
        }

        // POST: QuanLyHangGui/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHangGui,NgayGioGuiHang,TrongLuongHangGui,XacNhanHopLe")] QuanLiHangGui quanLiHangGui)
        {
            if (id != quanLiHangGui.MaHangGui)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLiHangGui);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLiHangGuiExists(quanLiHangGui.MaHangGui))
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
            return View(quanLiHangGui);
        }

        // GET: QuanLyHangGui/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.QuanLiHangGui == null)
            {
                return NotFound();
            }

            var quanLiHangGui = await _context.QuanLiHangGui
                .FirstOrDefaultAsync(m => m.MaHangGui == id);
            if (quanLiHangGui == null)
            {
                return NotFound();
            }

            return View(quanLiHangGui);
        }

        // POST: QuanLyHangGui/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.QuanLiHangGui == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuanLiHangGui'  is null.");
            }
            var quanLiHangGui = await _context.QuanLiHangGui.FindAsync(id);
            if (quanLiHangGui != null)
            {
                _context.QuanLiHangGui.Remove(quanLiHangGui);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLiHangGuiExists(string id)
        {
          return (_context.QuanLiHangGui?.Any(e => e.MaHangGui == id)).GetValueOrDefault();
        }
    }
}

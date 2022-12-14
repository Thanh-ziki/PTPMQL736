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
    public class QuanLiChuyenBayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLiChuyenBayController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuanLiChuyenBay
        public async Task<IActionResult> Index()
        {
              return _context.QuanLiChuyenBay != null ? 
                          View(await _context.QuanLiChuyenBay.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.QuanLiChuyenBay'  is null.");
        }

        // GET: QuanLiChuyenBay/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.QuanLiChuyenBay == null)
            {
                return NotFound();
            }

            var quanLiChuyenBay = await _context.QuanLiChuyenBay
                .FirstOrDefaultAsync(m => m.MaChuyenBay == id);
            if (quanLiChuyenBay == null)
            {
                return NotFound();
            }

            return View(quanLiChuyenBay);
        }

        // GET: QuanLiChuyenBay/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLiChuyenBay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuyenBay,SoHanhKhach,DiemKhoiHanh,DiemDen,ThoiGianXuatPhat")] QuanLiChuyenBay quanLiChuyenBay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLiChuyenBay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanLiChuyenBay);
        }

        // GET: QuanLiChuyenBay/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.QuanLiChuyenBay == null)
            {
                return NotFound();
            }

            var quanLiChuyenBay = await _context.QuanLiChuyenBay.FindAsync(id);
            if (quanLiChuyenBay == null)
            {
                return NotFound();
            }
            return View(quanLiChuyenBay);
        }

        // POST: QuanLiChuyenBay/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChuyenBay,SoHanhKhach,DiemKhoiHanh,DiemDen,ThoiGianXuatPhat")] QuanLiChuyenBay quanLiChuyenBay)
        {
            if (id != quanLiChuyenBay.MaChuyenBay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLiChuyenBay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLiChuyenBayExists(quanLiChuyenBay.MaChuyenBay))
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
            return View(quanLiChuyenBay);
        }

        // GET: QuanLiChuyenBay/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.QuanLiChuyenBay == null)
            {
                return NotFound();
            }

            var quanLiChuyenBay = await _context.QuanLiChuyenBay
                .FirstOrDefaultAsync(m => m.MaChuyenBay == id);
            if (quanLiChuyenBay == null)
            {
                return NotFound();
            }

            return View(quanLiChuyenBay);
        }

        // POST: QuanLiChuyenBay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.QuanLiChuyenBay == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuanLiChuyenBay'  is null.");
            }
            var quanLiChuyenBay = await _context.QuanLiChuyenBay.FindAsync(id);
            if (quanLiChuyenBay != null)
            {
                _context.QuanLiChuyenBay.Remove(quanLiChuyenBay);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLiChuyenBayExists(string id)
        {
          return (_context.QuanLiChuyenBay?.Any(e => e.MaChuyenBay == id)).GetValueOrDefault();
        }
    }
}

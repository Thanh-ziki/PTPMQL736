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
    public class CheckAccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckAccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckAccount
        public async Task<IActionResult> Index()
        {
              return _context.CheckAccount != null ? 
                          View(await _context.CheckAccount.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CheckAccount'  is null.");
        }

        // GET: CheckAccount/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.CheckAccount == null)
            {
                return NotFound();
            }

            var checkAccount = await _context.CheckAccount
                .FirstOrDefaultAsync(m => m.CheckUserName == id);
            if (checkAccount == null)
            {
                return NotFound();
            }

            return View(checkAccount);
        }

        // GET: CheckAccount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckAccount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckUserName,CheckPassword")] CheckAccount checkAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkAccount);
        }

        // GET: CheckAccount/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CheckAccount == null)
            {
                return NotFound();
            }

            var checkAccount = await _context.CheckAccount.FindAsync(id);
            if (checkAccount == null)
            {
                return NotFound();
            }
            return View(checkAccount);
        }

        // POST: CheckAccount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CheckUserName,CheckPassword")] CheckAccount checkAccount)
        {
            if (id != checkAccount.CheckUserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckAccountExists(checkAccount.CheckUserName))
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
            return View(checkAccount);
        }

        // GET: CheckAccount/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CheckAccount == null)
            {
                return NotFound();
            }

            var checkAccount = await _context.CheckAccount
                .FirstOrDefaultAsync(m => m.CheckUserName == id);
            if (checkAccount == null)
            {
                return NotFound();
            }

            return View(checkAccount);
        }

        // POST: CheckAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CheckAccount == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CheckAccount'  is null.");
            }
            var checkAccount = await _context.CheckAccount.FindAsync(id);
            if (checkAccount != null)
            {
                _context.CheckAccount.Remove(checkAccount);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckAccountExists(string id)
        {
          return (_context.CheckAccount?.Any(e => e.CheckUserName == id)).GetValueOrDefault();
        }
    }
}

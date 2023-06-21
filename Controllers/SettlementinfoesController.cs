using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projektMVC.Models;

namespace projektMVC.Controllers
{
    public class SettlementinfoesController : Controller
    {
        private readonly UbiContext _context;

        public SettlementinfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Settlementinfoes
        public async Task<IActionResult> Index()
        {
            var ubiContext = _context.Settlementinfos.Include(s => s.User);
            return View(await ubiContext.ToListAsync());
        }

        // GET: Settlementinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Settlementinfos == null)
            {
                return NotFound();
            }

            var settlementinfo = await _context.Settlementinfos
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Settlemenid == id);
            if (settlementinfo == null)
            {
                return NotFound();
            }

            return View(settlementinfo);
        }

        // GET: Settlementinfoes/Create
        public IActionResult Create()
        {
            ViewData["Userid"] = new SelectList(_context.Userinfos, "Userid", "Userid");
            return View();
        }

        // POST: Settlementinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Settlemenid,Accountbanknumber,Description,Status,Userid")] Settlementinfo settlementinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settlementinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Userid"] = new SelectList(_context.Userinfos, "Userid", "Userid", settlementinfo.Userid);
            return View(settlementinfo);
        }

        // GET: Settlementinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Settlementinfos == null)
            {
                return NotFound();
            }

            var settlementinfo = await _context.Settlementinfos.FindAsync(id);
            if (settlementinfo == null)
            {
                return NotFound();
            }
            ViewData["Userid"] = new SelectList(_context.Userinfos, "Userid", "Userid", settlementinfo.Userid);
            return View(settlementinfo);
        }

        // POST: Settlementinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Settlemenid,Accountbanknumber,Description,Status,Userid")] Settlementinfo settlementinfo)
        {
            if (id != settlementinfo.Settlemenid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settlementinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettlementinfoExists(settlementinfo.Settlemenid))
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
            ViewData["Userid"] = new SelectList(_context.Userinfos, "Userid", "Userid", settlementinfo.Userid);
            return View(settlementinfo);
        }

        // GET: Settlementinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Settlementinfos == null)
            {
                return NotFound();
            }

            var settlementinfo = await _context.Settlementinfos
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Settlemenid == id);
            if (settlementinfo == null)
            {
                return NotFound();
            }

            return View(settlementinfo);
        }

        // POST: Settlementinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Settlementinfos == null)
            {
                return Problem("Entity set 'UbiContext.Settlementinfos'  is null.");
            }
            var settlementinfo = await _context.Settlementinfos.FindAsync(id);
            if (settlementinfo != null)
            {
                _context.Settlementinfos.Remove(settlementinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettlementinfoExists(int id)
        {
          return (_context.Settlementinfos?.Any(e => e.Settlemenid == id)).GetValueOrDefault();
        }
    }
}

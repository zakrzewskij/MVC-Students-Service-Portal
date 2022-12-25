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
    public class GroupinfoesController : Controller
    {
        private readonly UbiContext _context;

        public GroupinfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Groupinfoes
        public async Task<IActionResult> Index()
        {
              return _context.Groupinfos != null ? 
                          View(await _context.Groupinfos.ToListAsync()) :
                          Problem("Entity set 'UbiContext.Groupinfos'  is null.");
        }

        // GET: Groupinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Groupinfos == null)
            {
                return NotFound();
            }

            var groupinfo = await _context.Groupinfos
                .FirstOrDefaultAsync(m => m.Groupid == id);
            if (groupinfo == null)
            {
                return NotFound();
            }

            return View(groupinfo);
        }

        // GET: Groupinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groupinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Groupid,Groupname,Description")] Groupinfo groupinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupinfo);
        }

        // GET: Groupinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Groupinfos == null)
            {
                return NotFound();
            }

            var groupinfo = await _context.Groupinfos.FindAsync(id);
            if (groupinfo == null)
            {
                return NotFound();
            }
            return View(groupinfo);
        }

        // POST: Groupinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Groupid,Groupname,Description")] Groupinfo groupinfo)
        {
            if (id != groupinfo.Groupid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupinfoExists(groupinfo.Groupid))
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
            return View(groupinfo);
        }

        // GET: Groupinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Groupinfos == null)
            {
                return NotFound();
            }

            var groupinfo = await _context.Groupinfos
                .FirstOrDefaultAsync(m => m.Groupid == id);
            if (groupinfo == null)
            {
                return NotFound();
            }

            return View(groupinfo);
        }

        // POST: Groupinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Groupinfos == null)
            {
                return Problem("Entity set 'UbiContext.Groupinfos'  is null.");
            }
            var groupinfo = await _context.Groupinfos.FindAsync(id);
            if (groupinfo != null)
            {
                _context.Groupinfos.Remove(groupinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupinfoExists(int id)
        {
          return (_context.Groupinfos?.Any(e => e.Groupid == id)).GetValueOrDefault();
        }
    }
}

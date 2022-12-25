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
    public class TimetableinfoesController : Controller
    {
        private readonly UbiContext _context;

        public TimetableinfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Timetableinfoes
        public async Task<IActionResult> Index()
        {
            var ubiContext = _context.Timetableinfos.Include(t => t.Course).Include(t => t.Group);
            return View(await ubiContext.ToListAsync());
        }

        // GET: Timetableinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Timetableinfos == null)
            {
                return NotFound();
            }

            var timetableinfo = await _context.Timetableinfos
                .Include(t => t.Course)
                .Include(t => t.Group)
                .FirstOrDefaultAsync(m => m.Timetableid == id);
            if (timetableinfo == null)
            {
                return NotFound();
            }

            return View(timetableinfo);
        }

        // GET: Timetableinfoes/Create
        public IActionResult Create()
        {
            ViewData["Courseid"] = new SelectList(_context.Courseinfos, "Courseid", "Courseid");
            ViewData["Groupid"] = new SelectList(_context.Groupinfos, "Groupid", "Groupid");
            return View();
        }

        // POST: Timetableinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Timetableid,Class,Courseid,Day,Period,Groupid")] Timetableinfo timetableinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timetableinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Courseid"] = new SelectList(_context.Courseinfos, "Courseid", "Courseid", timetableinfo.Courseid);
            ViewData["Groupid"] = new SelectList(_context.Groupinfos, "Groupid", "Groupid", timetableinfo.Groupid);
            return View(timetableinfo);
        }

        // GET: Timetableinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Timetableinfos == null)
            {
                return NotFound();
            }

            var timetableinfo = await _context.Timetableinfos.FindAsync(id);
            if (timetableinfo == null)
            {
                return NotFound();
            }
            ViewData["Courseid"] = new SelectList(_context.Courseinfos, "Courseid", "Courseid", timetableinfo.Courseid);
            ViewData["Groupid"] = new SelectList(_context.Groupinfos, "Groupid", "Groupid", timetableinfo.Groupid);
            return View(timetableinfo);
        }

        // POST: Timetableinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Timetableid,Class,Courseid,Day,Period,Groupid")] Timetableinfo timetableinfo)
        {
            if (id != timetableinfo.Timetableid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timetableinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimetableinfoExists(timetableinfo.Timetableid))
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
            ViewData["Courseid"] = new SelectList(_context.Courseinfos, "Courseid", "Courseid", timetableinfo.Courseid);
            ViewData["Groupid"] = new SelectList(_context.Groupinfos, "Groupid", "Groupid", timetableinfo.Groupid);
            return View(timetableinfo);
        }

        // GET: Timetableinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Timetableinfos == null)
            {
                return NotFound();
            }

            var timetableinfo = await _context.Timetableinfos
                .Include(t => t.Course)
                .Include(t => t.Group)
                .FirstOrDefaultAsync(m => m.Timetableid == id);
            if (timetableinfo == null)
            {
                return NotFound();
            }

            return View(timetableinfo);
        }

        // POST: Timetableinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Timetableinfos == null)
            {
                return Problem("Entity set 'UbiContext.Timetableinfos'  is null.");
            }
            var timetableinfo = await _context.Timetableinfos.FindAsync(id);
            if (timetableinfo != null)
            {
                _context.Timetableinfos.Remove(timetableinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimetableinfoExists(int id)
        {
          return (_context.Timetableinfos?.Any(e => e.Timetableid == id)).GetValueOrDefault();
        }
    }
}

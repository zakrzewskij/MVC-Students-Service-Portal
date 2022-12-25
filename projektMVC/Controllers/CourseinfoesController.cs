using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Graph;
using projektMVC.Models;

namespace projektMVC.Controllers
{
    public class CourseinfoesController : Controller
    {
        private readonly UbiContext _context;

        public CourseinfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Courseinfoes
        public async Task<IActionResult> Index()
        {
            var isNormalUser = Helpers.GroupHelpers.IsNormalUser(User.Claims);

            return _context.Courseinfos != null ? 
                          View(await _context.Courseinfos.ToListAsync()) :
                          Problem("Entity set 'UbiContext.Courseinfos'  is null.");
        }

        // GET: Courseinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courseinfos == null)
            {
                return NotFound();
            }

            var courseinfo = await _context.Courseinfos
                .FirstOrDefaultAsync(m => m.Courseid == id);
            if (courseinfo == null)
            {
                return NotFound();
            }

            return View(courseinfo);
        }

        // GET: Courseinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courseinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Courseid,Thema,Description")] Courseinfo courseinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseinfo);
        }

        // GET: Courseinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courseinfos == null)
            {
                return NotFound();
            }

            var courseinfo = await _context.Courseinfos.FindAsync(id);
            if (courseinfo == null)
            {
                return NotFound();
            }
            return View(courseinfo);
        }

        // POST: Courseinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Courseid,Thema,Description")] Courseinfo courseinfo)
        {
            if (id != courseinfo.Courseid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseinfoExists(courseinfo.Courseid))
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
            return View(courseinfo);
        }

        // GET: Courseinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courseinfos == null)
            {
                return NotFound();
            }

            var courseinfo = await _context.Courseinfos
                .FirstOrDefaultAsync(m => m.Courseid == id);
            if (courseinfo == null)
            {
                return NotFound();
            }

            return View(courseinfo);
        }

        // POST: Courseinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courseinfos == null)
            {
                return Problem("Entity set 'UbiContext.Courseinfos'  is null.");
            }
            var courseinfo = await _context.Courseinfos.FindAsync(id);
            if (courseinfo != null)
            {
                _context.Courseinfos.Remove(courseinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseinfoExists(int id)
        {
          return (_context.Courseinfos?.Any(e => e.Courseid == id)).GetValueOrDefault();
        }
    }
}

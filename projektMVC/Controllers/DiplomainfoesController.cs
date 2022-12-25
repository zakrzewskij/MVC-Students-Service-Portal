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
    public class DiplomainfoesController : Controller
    {
        private readonly UbiContext _context;

        public DiplomainfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Diplomainfoes
        public async Task<IActionResult> Index()
        {
            var ubiContext = _context.Diplomainfos.Include(d => d.File).Include(d => d.Reviewer).Include(d => d.Student).Include(d => d.WhouploadNavigation);
            return View(await ubiContext.ToListAsync());
        }

        // GET: Diplomainfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Diplomainfos == null)
            {
                return NotFound();
            }

            var diplomainfo = await _context.Diplomainfos
                .Include(d => d.File)
                .Include(d => d.Reviewer)
                .Include(d => d.Student)
                .Include(d => d.WhouploadNavigation)
                .FirstOrDefaultAsync(m => m.Diplomaid == id);
            if (diplomainfo == null)
            {
                return NotFound();
            }

            return View(diplomainfo);
        }

        // GET: Diplomainfoes/Create
        public IActionResult Create()
        {
            ViewData["Fileid"] = new SelectList(_context.Fileinfos, "Fileid", "Fileid");
            ViewData["Reviewerid"] = new SelectList(_context.Userinfos, "Userid", "Userid");
            ViewData["Studentid"] = new SelectList(_context.Userinfos, "Userid", "Userid");
            ViewData["Whoupload"] = new SelectList(_context.Userinfos, "Userid", "Userid");
            return View();
        }

        // POST: Diplomainfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Diplomaid,Description,Reviewerid,Promotorid,Theme,CreateDate,FinishDate,Status,Studentid,Fileid,Whoupload")] Diplomainfo diplomainfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diplomainfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Fileid"] = new SelectList(_context.Fileinfos, "Fileid", "Fileid", diplomainfo.Fileid);
            ViewData["Reviewerid"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Reviewerid);
            ViewData["Studentid"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Studentid);
            ViewData["Whoupload"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Whoupload);
            return View(diplomainfo);
        }

        // GET: Diplomainfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Diplomainfos == null)
            {
                return NotFound();
            }

            var diplomainfo = await _context.Diplomainfos.FindAsync(id);
            if (diplomainfo == null)
            {
                return NotFound();
            }
            ViewData["Fileid"] = new SelectList(_context.Fileinfos, "Fileid", "Fileid", diplomainfo.Fileid);
            ViewData["Reviewerid"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Reviewerid);
            ViewData["Studentid"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Studentid);
            ViewData["Whoupload"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Whoupload);
            return View(diplomainfo);
        }

        // POST: Diplomainfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Diplomaid,Description,Reviewerid,Promotorid,Theme,CreateDate,FinishDate,Status,Studentid,Fileid,Whoupload")] Diplomainfo diplomainfo)
        {
            if (id != diplomainfo.Diplomaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diplomainfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiplomainfoExists(diplomainfo.Diplomaid))
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
            ViewData["Fileid"] = new SelectList(_context.Fileinfos, "Fileid", "Fileid", diplomainfo.Fileid);
            ViewData["Reviewerid"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Reviewerid);
            ViewData["Studentid"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Studentid);
            ViewData["Whoupload"] = new SelectList(_context.Userinfos, "Userid", "Userid", diplomainfo.Whoupload);
            return View(diplomainfo);
        }

        // GET: Diplomainfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Diplomainfos == null)
            {
                return NotFound();
            }

            var diplomainfo = await _context.Diplomainfos
                .Include(d => d.File)
                .Include(d => d.Reviewer)
                .Include(d => d.Student)
                .Include(d => d.WhouploadNavigation)
                .FirstOrDefaultAsync(m => m.Diplomaid == id);
            if (diplomainfo == null)
            {
                return NotFound();
            }

            return View(diplomainfo);
        }

        // POST: Diplomainfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Diplomainfos == null)
            {
                return Problem("Entity set 'UbiContext.Diplomainfos'  is null.");
            }
            var diplomainfo = await _context.Diplomainfos.FindAsync(id);
            if (diplomainfo != null)
            {
                _context.Diplomainfos.Remove(diplomainfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiplomainfoExists(int id)
        {
          return (_context.Diplomainfos?.Any(e => e.Diplomaid == id)).GetValueOrDefault();
        }
    }
}

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
    public class FileinfoesController : Controller
    {
        private readonly UbiContext _context;

        public FileinfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Fileinfoes
        public async Task<IActionResult> Index()
        {
              return _context.Fileinfos != null ? 
                          View(await _context.Fileinfos.ToListAsync()) :
                          Problem("Entity set 'UbiContext.Fileinfos'  is null.");
        }

        // GET: Fileinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Fileinfos == null)
            {
                return NotFound();
            }

            var fileinfo = await _context.Fileinfos
                .FirstOrDefaultAsync(m => m.Fileid == id);
            if (fileinfo == null)
            {
                return NotFound();
            }

            return View(fileinfo);
        }

        // GET: Fileinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fileinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Fileid,FileName,FileDate,FileWeight,FileType")] Fileinfo fileinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fileinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileinfo);
        }

        // GET: Fileinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Fileinfos == null)
            {
                return NotFound();
            }

            var fileinfo = await _context.Fileinfos.FindAsync(id);
            if (fileinfo == null)
            {
                return NotFound();
            }
            return View(fileinfo);
        }

        // POST: Fileinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Fileid,FileName,FileDate,FileWeight,FileType")] Fileinfo fileinfo)
        {
            if (id != fileinfo.Fileid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fileinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FileinfoExists(fileinfo.Fileid))
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
            return View(fileinfo);
        }

        // GET: Fileinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Fileinfos == null)
            {
                return NotFound();
            }

            var fileinfo = await _context.Fileinfos
                .FirstOrDefaultAsync(m => m.Fileid == id);
            if (fileinfo == null)
            {
                return NotFound();
            }

            return View(fileinfo);
        }

        // POST: Fileinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Fileinfos == null)
            {
                return Problem("Entity set 'UbiContext.Fileinfos'  is null.");
            }
            var fileinfo = await _context.Fileinfos.FindAsync(id);
            if (fileinfo != null)
            {
                _context.Fileinfos.Remove(fileinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FileinfoExists(int id)
        {
          return (_context.Fileinfos?.Any(e => e.Fileid == id)).GetValueOrDefault();
        }
    }
}

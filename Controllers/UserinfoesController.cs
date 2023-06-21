using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projektMVC.Helpers;
using projektMVC.Models;

namespace projektMVC.Controllers
{
    public class UserinfoesController : Controller
    {
        private readonly UbiContext _context;

        public UserinfoesController(UbiContext context)
        {
            _context = context;
        }

        // GET: Userinfoes
        public async Task<IActionResult> Index()
        {
            var isNormalUser = GroupHelpers.IsNormalUser(User.Claims);
            var ubiContext = await _context.Userinfos.Include(u => u.Timetable).ToListAsync();
            if (isNormalUser && User.Identity?.Name is not null)
            {
                ubiContext = ubiContext.Where(x => x.Login == User.Identity.Name).ToList();
            }

            return View(ubiContext);
        }

        // GET: Userinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Userinfos == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfos
                .Include(u => u.Timetable)
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userinfo == null)
            {
                return NotFound();
            }

            return View(userinfo);
        }

        // GET: Userinfoes/Create
        public IActionResult Create()
        {
            ViewData["Timetableid"] = new SelectList(_context.Timetableinfos, "Timetableid", "Timetableid");
            return View();
        }

        // POST: Userinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userid,Password,Prefix,Username,Login,LastLoginDate,CreateAccountDate,StatusAccount,Timetableid")] Userinfo userinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Timetableid"] = new SelectList(_context.Timetableinfos, "Timetableid", "Timetableid", userinfo.Timetableid);
            return View(userinfo);
        }

        // GET: Userinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userinfos == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfos.FindAsync(id);
            if (userinfo == null)
            {
                return NotFound();
            }
            ViewData["Timetableid"] = new SelectList(_context.Timetableinfos, "Timetableid", "Timetableid", userinfo.Timetableid);
            return View(userinfo);
        }

        // POST: Userinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Userid,Password,Prefix,Username,Login,LastLoginDate,CreateAccountDate,StatusAccount,Timetableid")] Userinfo userinfo)
        {
            if (id != userinfo.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserinfoExists(userinfo.Userid))
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
            ViewData["Timetableid"] = new SelectList(_context.Timetableinfos, "Timetableid", "Timetableid", userinfo.Timetableid);
            return View(userinfo);
        }

        // GET: Userinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userinfos == null)
            {
                return NotFound();
            }

            var userinfo = await _context.Userinfos
                .Include(u => u.Timetable)
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (userinfo == null)
            {
                return NotFound();
            }

            return View(userinfo);
        }

        // POST: Userinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userinfos == null)
            {
                return Problem("Entity set 'UbiContext.Userinfos'  is null.");
            }
            var userinfo = await _context.Userinfos.FindAsync(id);
            if (userinfo != null)
            {
                _context.Userinfos.Remove(userinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserinfoExists(int id)
        {
          return (_context.Userinfos?.Any(e => e.Userid == id)).GetValueOrDefault();
        }
    }
}

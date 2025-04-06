using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitFlow.Data;
using RecruitFlow.Models;

namespace RecruitFlow.Controllers
{
    public class NganhNgheController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NganhNgheController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NganhNghe
        public async Task<IActionResult> Index()
        {
            return View(await _context.NganhNghe.ToListAsync());
        }

        // GET: NganhNghe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhNghe = await _context.NganhNghe
                .FirstOrDefaultAsync(m => m.NganhNgheId == id);
            if (nganhNghe == null)
            {
                return NotFound();
            }

            return View(nganhNghe);
        }

        // GET: NganhNghe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NganhNghe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NganhNgheId,TenNganhNghe")] NganhNghe nganhNghe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nganhNghe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nganhNghe);
        }

        // GET: NganhNghe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhNghe = await _context.NganhNghe.FindAsync(id);
            if (nganhNghe == null)
            {
                return NotFound();
            }
            return View(nganhNghe);
        }

        // POST: NganhNghe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NganhNgheId,TenNganhNghe")] NganhNghe nganhNghe)
        {
            if (id != nganhNghe.NganhNgheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nganhNghe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NganhNgheExists(nganhNghe.NganhNgheId))
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
            return View(nganhNghe);
        }

        // GET: NganhNghe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nganhNghe = await _context.NganhNghe
                .FirstOrDefaultAsync(m => m.NganhNgheId == id);
            if (nganhNghe == null)
            {
                return NotFound();
            }

            return View(nganhNghe);
        }

        // POST: NganhNghe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nganhNghe = await _context.NganhNghe.FindAsync(id);
            _context.NganhNghe.Remove(nganhNghe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NganhNgheExists(int id)
        {
            return _context.NganhNghe.Any(e => e.NganhNgheId == id);
        }
    }
}

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
    public class PhanLoaiNganhNgheController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhanLoaiNganhNgheController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhanLoaiNganhNghe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PhanLoaiNganhNghe.Include(p => p.NganhNghe).Include(p => p.TinTuyenDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PhanLoaiNganhNghe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanLoaiNganhNghe = await _context.PhanLoaiNganhNghe
                .Include(p => p.NganhNghe)
                .Include(p => p.TinTuyenDung)
                .FirstOrDefaultAsync(m => m.TinTuyenDungId == id);
            if (phanLoaiNganhNghe == null)
            {
                return NotFound();
            }

            return View(phanLoaiNganhNghe);
        }

        // GET: PhanLoaiNganhNghe/Create
        public IActionResult Create()
        {
            ViewData["NganhNgheId"] = new SelectList(_context.NganhNghe, "NganhNgheId", "NganhNgheId");
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe");
            return View();
        }

        // POST: PhanLoaiNganhNghe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TinTuyenDungId,NganhNgheId")] PhanLoaiNganhNghe phanLoaiNganhNghe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanLoaiNganhNghe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NganhNgheId"] = new SelectList(_context.NganhNghe, "NganhNgheId", "NganhNgheId", phanLoaiNganhNghe.NganhNgheId);
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", phanLoaiNganhNghe.TinTuyenDungId);
            return View(phanLoaiNganhNghe);
        }

        // GET: PhanLoaiNganhNghe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanLoaiNganhNghe = await _context.PhanLoaiNganhNghe.FindAsync(id);
            if (phanLoaiNganhNghe == null)
            {
                return NotFound();
            }
            ViewData["NganhNgheId"] = new SelectList(_context.NganhNghe, "NganhNgheId", "NganhNgheId", phanLoaiNganhNghe.NganhNgheId);
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", phanLoaiNganhNghe.TinTuyenDungId);
            return View(phanLoaiNganhNghe);
        }

        // POST: PhanLoaiNganhNghe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TinTuyenDungId,NganhNgheId")] PhanLoaiNganhNghe phanLoaiNganhNghe)
        {
            if (id != phanLoaiNganhNghe.TinTuyenDungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanLoaiNganhNghe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanLoaiNganhNgheExists(phanLoaiNganhNghe.TinTuyenDungId))
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
            ViewData["NganhNgheId"] = new SelectList(_context.NganhNghe, "NganhNgheId", "NganhNgheId", phanLoaiNganhNghe.NganhNgheId);
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", phanLoaiNganhNghe.TinTuyenDungId);
            return View(phanLoaiNganhNghe);
        }

        // GET: PhanLoaiNganhNghe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phanLoaiNganhNghe = await _context.PhanLoaiNganhNghe
                .Include(p => p.NganhNghe)
                .Include(p => p.TinTuyenDung)
                .FirstOrDefaultAsync(m => m.TinTuyenDungId == id);
            if (phanLoaiNganhNghe == null)
            {
                return NotFound();
            }

            return View(phanLoaiNganhNghe);
        }

        // POST: PhanLoaiNganhNghe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanLoaiNganhNghe = await _context.PhanLoaiNganhNghe.FindAsync(id);
            _context.PhanLoaiNganhNghe.Remove(phanLoaiNganhNghe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhanLoaiNganhNgheExists(int id)
        {
            return _context.PhanLoaiNganhNghe.Any(e => e.TinTuyenDungId == id);
        }
    }
}

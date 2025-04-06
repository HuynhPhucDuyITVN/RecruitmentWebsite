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
    public class LichPhongVanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LichPhongVanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LichPhongVan
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LichPhongVan.Include(l => l.DonUngTuyen);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LichPhongVan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichPhongVan = await _context.LichPhongVan
                .Include(l => l.DonUngTuyen)
                .FirstOrDefaultAsync(m => m.LichPhongVanId == id);
            if (lichPhongVan == null)
            {
                return NotFound();
            }

            return View(lichPhongVan);
        }

        // GET: LichPhongVan/Create
        public IActionResult Create()
        {
            ViewData["DonUngTuyenId"] = new SelectList(_context.DonUngTuyen, "DonUngTuyenId", "DonUngTuyenId");
            return View();
        }

        // POST: LichPhongVan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LichPhongVanId,DonUngTuyenId,ThoiGianPhongVan,HinhThucPhongVan,DiaDiemPhongVan,NguoiPhongVan,GhiChu,ThoiGianTao")] LichPhongVan lichPhongVan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichPhongVan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonUngTuyenId"] = new SelectList(_context.DonUngTuyen, "DonUngTuyenId", "DonUngTuyenId", lichPhongVan.DonUngTuyenId);
            return View(lichPhongVan);
        }

        // GET: LichPhongVan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichPhongVan = await _context.LichPhongVan.FindAsync(id);
            if (lichPhongVan == null)
            {
                return NotFound();
            }
            ViewData["DonUngTuyenId"] = new SelectList(_context.DonUngTuyen, "DonUngTuyenId", "DonUngTuyenId", lichPhongVan.DonUngTuyenId);
            return View(lichPhongVan);
        }

        // POST: LichPhongVan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LichPhongVanId,DonUngTuyenId,ThoiGianPhongVan,HinhThucPhongVan,DiaDiemPhongVan,NguoiPhongVan,GhiChu,ThoiGianTao")] LichPhongVan lichPhongVan)
        {
            if (id != lichPhongVan.LichPhongVanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichPhongVan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichPhongVanExists(lichPhongVan.LichPhongVanId))
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
            ViewData["DonUngTuyenId"] = new SelectList(_context.DonUngTuyen, "DonUngTuyenId", "DonUngTuyenId", lichPhongVan.DonUngTuyenId);
            return View(lichPhongVan);
        }

        // GET: LichPhongVan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichPhongVan = await _context.LichPhongVan
                .Include(l => l.DonUngTuyen)
                .FirstOrDefaultAsync(m => m.LichPhongVanId == id);
            if (lichPhongVan == null)
            {
                return NotFound();
            }

            return View(lichPhongVan);
        }

        // POST: LichPhongVan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichPhongVan = await _context.LichPhongVan.FindAsync(id);
            _context.LichPhongVan.Remove(lichPhongVan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichPhongVanExists(int id)
        {
            return _context.LichPhongVan.Any(e => e.LichPhongVanId == id);
        }
    }
}

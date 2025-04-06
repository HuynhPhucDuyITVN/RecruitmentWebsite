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
    public class TinTuyenDungController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TinTuyenDungController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TinTuyenDung
        public async Task<IActionResult> Index()
        {
            return View(await _context.TinTuyenDung.ToListAsync());
        }

        // GET: TinTuyenDung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuyenDung = await _context.TinTuyenDung
                .FirstOrDefaultAsync(m => m.TinTuyenDungId == id);
            if (tinTuyenDung == null)
            {
                return NotFound();
            }

            return View(tinTuyenDung);
        }

        // GET: TinTuyenDung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TinTuyenDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TinTuyenDungId,TieuDe,BoPhan,LoaiCongViec,LuongTu,LuongDen,DiaDiem,CapDoKinhNghiem,MoTa,YeuCau,PhucLoi,HanChot,DaCongKhai,ThoiGianCongKhai,ThoiGianTao")] TinTuyenDung tinTuyenDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinTuyenDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinTuyenDung);
        }

        // GET: TinTuyenDung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuyenDung = await _context.TinTuyenDung.FindAsync(id);
            if (tinTuyenDung == null)
            {
                return NotFound();
            }
            return View(tinTuyenDung);
        }

        // POST: TinTuyenDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TinTuyenDungId,TieuDe,BoPhan,LoaiCongViec,LuongTu,LuongDen,DiaDiem,CapDoKinhNghiem,MoTa,YeuCau,PhucLoi,HanChot,DaCongKhai,ThoiGianCongKhai,ThoiGianTao")] TinTuyenDung tinTuyenDung)
        {
            if (id != tinTuyenDung.TinTuyenDungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinTuyenDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinTuyenDungExists(tinTuyenDung.TinTuyenDungId))
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
            return View(tinTuyenDung);
        }

        // GET: TinTuyenDung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinTuyenDung = await _context.TinTuyenDung
                .FirstOrDefaultAsync(m => m.TinTuyenDungId == id);
            if (tinTuyenDung == null)
            {
                return NotFound();
            }

            return View(tinTuyenDung);
        }

        // POST: TinTuyenDung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinTuyenDung = await _context.TinTuyenDung.FindAsync(id);
            _context.TinTuyenDung.Remove(tinTuyenDung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinTuyenDungExists(int id)
        {
            return _context.TinTuyenDung.Any(e => e.TinTuyenDungId == id);
        }
    }
}

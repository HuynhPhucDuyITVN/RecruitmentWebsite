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
    public class GhiChuAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GhiChuAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GhiChuAdmin
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GhiChuAdmin.Include(g => g.NguoiTao).Include(g => g.TinTuyenDung).Include(g => g.UngVien).ThenInclude(nd => nd.NguoiDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GhiChuAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghiChuAdmin = await _context.GhiChuAdmin
                .Include(g => g.NguoiTao)
                .Include(g => g.TinTuyenDung)
                .Include(g => g.UngVien).ThenInclude(nd => nd.NguoiDung)
                .FirstOrDefaultAsync(m => m.GhiChuId == id);
            if (ghiChuAdmin == null)
            {
                return NotFound();
            }

            return View(ghiChuAdmin);
        }

        // GET: GhiChuAdmin/Create
        public IActionResult Create()
        {
            ViewData["NguoiTaoId"] = new SelectList(_context.NguoiDung.Where(nd => nd.VaiTro == "Admin"), "NguoiDungId", "TenDayDu");
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe");
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd =>nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu");
            return View();
        }

        // POST: GhiChuAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GhiChuId,UngVienId,TinTuyenDungId,NguoiTaoId,GhiChu,ThoiGianTao")] GhiChuAdmin ghiChuAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ghiChuAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiTaoId"] = new SelectList(_context.NguoiDung.Where(nd => nd.VaiTro == "Admin"), "NguoiDungId", "TenDayDu", ghiChuAdmin.NguoiTaoId);
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", ghiChuAdmin.TinTuyenDungId);
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd => nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", ghiChuAdmin.UngVienId);
            return View(ghiChuAdmin);
        }

        // GET: GhiChuAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghiChuAdmin = await _context.GhiChuAdmin.FindAsync(id);
            if (ghiChuAdmin == null)
            {
                return NotFound();
            }
            ViewData["NguoiTaoId"] = new SelectList(_context.NguoiDung.Where(nd => nd.VaiTro == "Admin"), "NguoiDungId", "TenDayDu", ghiChuAdmin.NguoiTaoId);
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", ghiChuAdmin.TinTuyenDungId);
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd => nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", ghiChuAdmin.UngVienId);
            return View(ghiChuAdmin);
        }

        // POST: GhiChuAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GhiChuId,UngVienId,TinTuyenDungId,NguoiTaoId,GhiChu,ThoiGianTao")] GhiChuAdmin ghiChuAdmin)
        {
            if (id != ghiChuAdmin.GhiChuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ghiChuAdmin.ThoiGianTao = DateTime.Now;
                    _context.Update(ghiChuAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GhiChuAdminExists(ghiChuAdmin.GhiChuId))
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
            ViewData["NguoiTaoId"] = new SelectList(_context.NguoiDung.Where(nd => nd.VaiTro == "Admin"), "NguoiDungId", "TenDayDu", ghiChuAdmin.NguoiTaoId);
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", ghiChuAdmin.TinTuyenDungId);
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd => nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", ghiChuAdmin.UngVienId);
            return View(ghiChuAdmin);
        }

        // GET: GhiChuAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ghiChuAdmin = await _context.GhiChuAdmin
                .Include(g => g.NguoiTao)
                .Include(g => g.TinTuyenDung)
                .Include(g => g.UngVien)
                .ThenInclude(nd => nd.NguoiDung)
                .FirstOrDefaultAsync(m => m.GhiChuId == id);
            if (ghiChuAdmin == null)
            {
                return NotFound();
            }

            return View(ghiChuAdmin);
        }

        // POST: GhiChuAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ghiChuAdmin = await _context.GhiChuAdmin.FindAsync(id);
            _context.GhiChuAdmin.Remove(ghiChuAdmin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GhiChuAdminExists(int id)
        {
            return _context.GhiChuAdmin.Any(e => e.GhiChuId == id);
        }
    }
}

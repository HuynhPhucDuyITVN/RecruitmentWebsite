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
    public class ThongBaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThongBaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThongBao
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ThongBao.Include(t => t.NguoiDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ThongBao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongBao = await _context.ThongBao
                .Include(t => t.NguoiDung)
                .FirstOrDefaultAsync(m => m.ThongBaoId == id);
            if (thongBao == null)
            {
                return NotFound();
            }

            return View(thongBao);
        }

        // GET: ThongBao/Create
        public IActionResult Create()
        {
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email");
            return View();
        }

        // POST: ThongBao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThongBaoId,NguoiDungId,LoaiSuKien,MaDinhDanhLienQuan,NoiDungThongBao,ThoiGianGui")] ThongBao thongBao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongBao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email", thongBao.NguoiDungId);
            return View(thongBao);
        }

        // GET: ThongBao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongBao = await _context.ThongBao.FindAsync(id);
            if (thongBao == null)
            {
                return NotFound();
            }
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email", thongBao.NguoiDungId);
            return View(thongBao);
        }

        // POST: ThongBao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThongBaoId,NguoiDungId,LoaiSuKien,MaDinhDanhLienQuan,NoiDungThongBao,ThoiGianGui")] ThongBao thongBao)
        {
            if (id != thongBao.ThongBaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongBao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongBaoExists(thongBao.ThongBaoId))
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
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email", thongBao.NguoiDungId);
            return View(thongBao);
        }

        // GET: ThongBao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongBao = await _context.ThongBao
                .Include(t => t.NguoiDung)
                .FirstOrDefaultAsync(m => m.ThongBaoId == id);
            if (thongBao == null)
            {
                return NotFound();
            }

            return View(thongBao);
        }

        // POST: ThongBao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thongBao = await _context.ThongBao.FindAsync(id);
            _context.ThongBao.Remove(thongBao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongBaoExists(int id)
        {
            return _context.ThongBao.Any(e => e.ThongBaoId == id);
        }
    }
}

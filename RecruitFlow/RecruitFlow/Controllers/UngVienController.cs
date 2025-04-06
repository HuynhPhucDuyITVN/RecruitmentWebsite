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
    public class UngVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UngVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UngVien
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UngVien.Include(u => u.NguoiDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UngVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ungVien = await _context.UngVien
                .Include(u => u.NguoiDung)
                .FirstOrDefaultAsync(m => m.UngVienId == id);
            if (ungVien == null)
            {
                return NotFound();
            }

            return View(ungVien);
        }

        // GET: UngVien/Create
        public IActionResult Create()
        {
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email");
            return View();
        }

        // POST: UngVien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UngVienId,NguoiDungId,GioiTinh,NgaySinh,DiaChi,TomTatHoSo")] UngVien ungVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ungVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email", ungVien.NguoiDungId);
            return View(ungVien);
        }

        // GET: UngVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ungVien = await _context.UngVien.FindAsync(id);
            if (ungVien == null)
            {
                return NotFound();
            }
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email", ungVien.NguoiDungId);
            return View(ungVien);
        }

        // POST: UngVien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UngVienId,NguoiDungId,GioiTinh,NgaySinh,DiaChi,TomTatHoSo")] UngVien ungVien)
        {
            if (id != ungVien.UngVienId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ungVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UngVienExists(ungVien.UngVienId))
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
            ViewData["NguoiDungId"] = new SelectList(_context.NguoiDung, "NguoiDungId", "Email", ungVien.NguoiDungId);
            return View(ungVien);
        }

        // GET: UngVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ungVien = await _context.UngVien
                .Include(u => u.NguoiDung)
                .FirstOrDefaultAsync(m => m.UngVienId == id);
            if (ungVien == null)
            {
                return NotFound();
            }

            return View(ungVien);
        }

        // POST: UngVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ungVien = await _context.UngVien.FindAsync(id);
            _context.UngVien.Remove(ungVien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UngVienExists(int id)
        {
            return _context.UngVien.Any(e => e.UngVienId == id);
        }
    }
}

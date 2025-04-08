using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitFlow.Data;
using RecruitFlow.Models;

namespace RecruitFlow.Controllers
{
    public class CvController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CvController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cv
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cv.Include(c => c.UngVien).ThenInclude(uv =>uv.NguoiDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cv/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.Cv
                .Include(c => c.UngVien).ThenInclude(uv => uv.NguoiDung)
                .FirstOrDefaultAsync(m => m.Cvid == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // GET: Cv/Create
        public IActionResult Create()
        {
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(uv => uv.NguoiDung), "UngVienId", "NguoiDung.TenDayDu");
            return View();
        }

        // POST: Cv/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cvid,UngVienId,TieuDe,FileUrl,ThoiGianTao")] Cv cv, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    cv.FileUrl = Upload(file);
                }
                _context.Add(cv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(uv => uv.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", cv.UngVienId);
            return View(cv);
        }

        // GET: Cv/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.Cv.FindAsync(id);
            if (cv == null)
            {
                return NotFound();
            }
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(uv => uv.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", cv.UngVienId);
            return View(cv);
        }

        // POST: Cv/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cvid,UngVienId,TieuDe,FileUrl,ThoiGianTao")] Cv cv, IFormFile file)
        {
            if (id != cv.Cvid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        cv.FileUrl = Upload(file);

                    }
                    cv.ThoiGianTao = DateTime.Now;
                    _context.Update(cv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CvExists(cv.Cvid))
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
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(uv => uv.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", cv.UngVienId);
            return View(cv);
        }

        // GET: Cv/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cv = await _context.Cv
                .Include(c => c.UngVien).ThenInclude(uv => uv.NguoiDung)
                .FirstOrDefaultAsync(m => m.Cvid == id);
            if (cv == null)
            {
                return NotFound();
            }

            return View(cv);
        }

        // POST: Cv/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cv = await _context.Cv.FindAsync(id);
            _context.Cv.Remove(cv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public string Upload(IFormFile file)
        {
            string uploadFileName = null;
            if (file != null)
            {
                uploadFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var folderPath = $"wwwroot\\file\\CV\\";
                var path = Path.Combine(folderPath, uploadFileName);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return uploadFileName;
        }

        private bool CvExists(int id)
        {
            return _context.Cv.Any(e => e.Cvid == id);
        }
    }
}

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
    public class DonUngTuyenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonUngTuyenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DonUngTuyen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonUngTuyen.Include(d => d.TinTuyenDung).Include(d => d.UngVien).ThenInclude(nd => nd.NguoiDung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DonUngTuyen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donUngTuyen = await _context.DonUngTuyen
                .Include(d => d.TinTuyenDung)
                .Include(d => d.UngVien).ThenInclude(nd => nd.NguoiDung)
                .FirstOrDefaultAsync(m => m.DonUngTuyenId == id);
            if (donUngTuyen == null)
            {
                return NotFound();
            }

            return View(donUngTuyen);
        }

        // GET: DonUngTuyen/Create
        public IActionResult Create()
        {
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe");
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd => nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu");
            return View();
        }

        // POST: DonUngTuyen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonUngTuyenId,TinTuyenDungId,UngVienId,Cvurl,ThuXinViec,ThoiGianNop,TrangThai")] DonUngTuyen donUngTuyen, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    donUngTuyen.Cvurl = Upload(file);
                }
                _context.Add(donUngTuyen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", donUngTuyen.TinTuyenDungId);
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd => nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", donUngTuyen.UngVienId);
            return View(donUngTuyen);
        }

        // GET: DonUngTuyen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donUngTuyen = await _context.DonUngTuyen.FindAsync(id);
            if (donUngTuyen == null)
            {
                return NotFound();
            }
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", donUngTuyen.TinTuyenDungId);
            ViewData["UngVienId"] = new SelectList(_context.UngVien.Include(nd => nd.NguoiDung), "UngVienId", "NguoiDung.TenDayDu", donUngTuyen.UngVienId);
            ViewBag.TrangThaiList = new SelectList(new List<string>
            {
                "Đang chờ",
                "Đã xem",
                "Phỏng vấn",
                "Từ chối",
                "Chấp nhận"
            });
            return View(donUngTuyen);
        }

        // POST: DonUngTuyen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonUngTuyenId,TinTuyenDungId,UngVienId,Cvurl,ThuXinViec,ThoiGianNop,TrangThai")] DonUngTuyen donUngTuyen, IFormFile file)
        {
            if (id != donUngTuyen.DonUngTuyenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (file != null)
                    {
                        donUngTuyen.Cvurl = Upload(file);
                    }
                    donUngTuyen.ThoiGianNop = DateTime.Now;
                    _context.Update(donUngTuyen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonUngTuyenExists(donUngTuyen.DonUngTuyenId))
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
            ViewData["TinTuyenDungId"] = new SelectList(_context.TinTuyenDung, "TinTuyenDungId", "TieuDe", donUngTuyen.TinTuyenDungId);
            ViewData["UngVienId"] = new SelectList(_context.UngVien, "UngVienId", "UngVienId", donUngTuyen.UngVienId);
            return View(donUngTuyen);
        }

        // GET: DonUngTuyen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donUngTuyen = await _context.DonUngTuyen
                .Include(d => d.TinTuyenDung)
                .Include(d => d.UngVien).ThenInclude(nd => nd.NguoiDung)
                .FirstOrDefaultAsync(m => m.DonUngTuyenId == id);
            if (donUngTuyen == null)
            {
                return NotFound();
            }

            return View(donUngTuyen);
        }

        // POST: DonUngTuyen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donUngTuyen = await _context.DonUngTuyen.FindAsync(id);
            _context.DonUngTuyen.Remove(donUngTuyen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public string Upload(IFormFile file)
        {
            string uploadFileName = null;
            if (file != null)
            {
                uploadFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                var folderPath = $"wwwroot\\file\\CVUngTuyen\\";
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

        private bool DonUngTuyenExists(int id)
        {
            return _context.DonUngTuyen.Any(e => e.DonUngTuyenId == id);
        }
    }
}

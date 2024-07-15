using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Areas.GiaoVien.Models;
using WebQLHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLHS.Areas.GiaoVien.Controllers
{
    [Area("giaovien")]
    [Route("giaovien")]
    [Route("giaovien/diemdanh")]
    public class DiemDanhController : Controller
    {
        private readonly QLHS_1Context _context;

        public DiemDanhController(QLHS_1Context context)
        {
            _context = context;
        }

        //[Route("index")]
        public async Task<IActionResult> Index(string maLopHoc, DateTime? ngay)
        {
            if (!ngay.HasValue)
            {
                ngay = DateTime.Today;
            }

            var hocSinhs = await _context.HocSinhs
                .Where(hs => hs.MaLopHoc == maLopHoc)
                .ToListAsync();

            var diemDanhList = hocSinhs.Select(hs => new DiemDanhViewModel
            {
                MaHs = hs.MaHs,
                HoTen = hs.HoTen,
                TrangThai = false,
                GhiChu = ""
            }).ToList();

            var viewModel = new DiemDanhListViewModel
            {
                MaLopHoc = maLopHoc,
                Ngay = ngay.Value,
                DiemDanhList = diemDanhList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveDiemDanh(DiemDanhListViewModel model)
        {
            TempData["Message"] = "";

            if (model == null || model.DiemDanhList == null)
            {
                LogValidationErrors();
                TempData["Message"] = "Lỗi dữ liệu.";
                return RedirectToAction("Index", new { maLopHoc = model?.MaLopHoc, ngay = model?.Ngay });
            }

            try
            {
                foreach (var item in model.DiemDanhList)
                {
                    var diemDanh = new DiemDanh
                    {
                        MaHs = item.MaHs,
                        Ngay = model.Ngay,
                        TrangThai = item.TrangThai,
                        GhiChu = item.GhiChu
                    };

                    _context.DiemDanhs.Add(diemDanh);
                }

                await _context.SaveChangesAsync();
                TempData["Message"] = "Điểm danh thành công.";
                return RedirectToAction("Index", new { maLopHoc = model.MaLopHoc, ngay = model.Ngay });
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Lỗi khi lưu điểm danh: " + ex.Message;
                return RedirectToAction("Index", new { maLopHoc = model.MaLopHoc, ngay = model.Ngay });
            }
        }
        //Log error
        private void LogValidationErrors()
        {
            foreach (var key in ModelState.Keys)
            {
                var state = ModelState[key];
                foreach (var error in state.Errors)
                {
                    // Log each validation error
                    Console.WriteLine($"Error for {key}: {error.ErrorMessage}");
                }
            }
        }
    }
}

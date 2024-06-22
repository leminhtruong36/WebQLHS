using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Globalization;
using WebQLHS.Models;
using WebQLHS.Models.Authentication;

namespace WebQLHS.Areas.Admin.Controllers
{
    [Authentication]
    [Area("admin")]
	[Route("admin")]
	[Route("admin/homeadmin")]
	public class HomeAdminController : Controller
	{
		QLHS_1Context db = new QLHS_1Context();
		[Route("")]
		[Route("index")]
		public IActionResult Index()
		{
			return View();
		}

		//Danh sach cac lop hoc
		[Route("danhsachlophoc")]
		public IActionResult DanhSachLopHoc()
		{
			var listLop = db.Lops.ToList();
			return View(listLop);
		}

		//Them lop hoc moi 
		[Route("themlopmoi")]
		[HttpGet]
		public IActionResult ThemLopMoi()
		{
			return View();
		}
		[Route("themlopmoi")]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ThemLopMoi([Bind("MaLopHoc,TenLop,SiSo")] Lop lopHoc)
		{
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
                db.Lops.Add(lopHoc);
				db.SaveChanges();
                TempData["Message"] = "Thêm thành công.";
                return RedirectToAction("DanhSachLopHoc");
            }
            return View(lopHoc);
        }

		//Sua thong tin lop hoc
        [Route("sualophoc")]
        [HttpGet]
        public IActionResult SuaLopHoc(string maLop)
        {
			var lopHoc = db.Lops.Find(maLop);
            return View(lopHoc);
        }
        [Route("sualophoc")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaLopHoc(Lop lopHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopHoc).State= EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSachLopHoc","HomeAdmin");
            }
            return View(lopHoc);
        }

        //Xoa lop hoc
        [Route("xoalophoc")]
        [HttpGet]
        public IActionResult XoaLopHoc(string maLop)
        {
            TempData["Message"] = "";

            var lopHoc = db.Lops.FirstOrDefault(m => m.MaLopHoc == maLop);

            if (lopHoc != null)
            {
                // Xóa các nhân viên liên quan
                var nhanViens = db.NhanViens.Where(nv => nv.MaLopHoc == maLop).ToList();
                db.NhanViens.RemoveRange(nhanViens);

                // Xóa các bài tập liên quan nếu cần
                var baiTaps = db.BaiTaps.Where(bt => bt.MaLopHoc == maLop).ToList();
                db.BaiTaps.RemoveRange(baiTaps);

                // Xóa các học sinh liên quan nếu cần
                var hocSinhs = db.HocSinhs.Where(hs => hs.MaLopHoc == maLop).ToList();
                db.HocSinhs.RemoveRange(hocSinhs);

                // Xóa lớp học
                db.Lops.Remove(lopHoc);
                db.SaveChanges();

                TempData["Message"] = "Xóa lớp học thành công.";
            }
            else
            {
                TempData["Message"] = "Không tìm thấy lớp học.";
            }

            return RedirectToAction("DanhSachLopHoc", "HomeAdmin");
        }


        //Danh sach cac giao vien
        [Route("danhsachnhanvien")]
        public IActionResult DanhSachNhanVien()
        {
            var listNV = db.NhanViens.ToList();
            return View(listNV);
        }

        //Sua thong tin nhan vien
        [Route("suanhanvien")]
        [HttpGet]
        public IActionResult SuaNhanVien(string maNV)
        {
            var nhanVien = db.NhanViens.Find(maNV);
            return View(nhanVien);
        }
        [Route("suanhanvien")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaNhanVien(NhanVien nhanVien)
        {
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(nhanVien).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Message"] = "Lưu thành công.";
                    return RedirectToAction("DanhSachNhanVien", "HomeAdmin");
                }
                catch (DbUpdateException ex)
                {
                    TempData["Message"] = "Lỗi khi lưu dữ liệu: " + ex.Message;
                    // Ghi log lỗi để xem chi tiết lỗi
                    LogValidationErrors();
                    // Example: _logger.LogError($"Error while saving NhanVien: {ex.Message}");
                }
            }
            else
            {
                // Log validation errors
                LogValidationErrors();
            }

            TempData["Message"] = "Lưu không thành công.";
            return View(nhanVien);
        }

        //Them lop hoc moi 
		[Route("themnhanvienmoi")]
		[HttpGet]
		public IActionResult ThemNhanVienMoi()
		{
			return View();
		}
        [Route("themnhanvienmoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemNhanVienMoi(NhanVien nhanVien)
        {
            TempData["Message"] = "";
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                TempData["Message"] = "Thêm thành công.";
                return RedirectToAction("DanhSachNhanVien");
            }
            return View(nhanVien);
        }

        //Xoa nhan vien
        [Route("xoanhanvien")]
        [HttpGet]
        public IActionResult XoaNhanVien(string maNV)
        {
            TempData["Message"] = "";

            var nhanVien = db.NhanViens.FirstOrDefault(m => m.MaNv == maNV);

            if (nhanVien != null)
            {
                // Xóa các bai tap liên quan
                var baiTaps = db.BaiTaps.Where(bt => bt.MaNv == maNV).ToList();
                db.BaiTaps.RemoveRange(baiTaps);

                // Xóa các chuc vu liên quan nếu cần
                var chucVus = db.ChucVus.Where(cv => cv.MaNv == maNV).ToList();
                db.ChucVus.RemoveRange(chucVus);

                // Xóa các nhap diem liên quan nếu cần
                var nhapDiems = db.NhapDiems.Where(nd => nd.MaNv == maNV).ToList();
                db.NhapDiems.RemoveRange(nhapDiems);

                // Xóa các nhap diem liên quan nếu cần
                var thuChis = db.ThuChis.Where(tc => tc.MaNv == maNV).ToList();
                db.ThuChis.RemoveRange(thuChis);

                // Xóa các nhap diem liên quan nếu cần
                var tkbs = db.Tkbs.Where(tkb => tkb.MaNv == maNV).ToList();
                db.Tkbs.RemoveRange(tkbs);

                // Xóa nhan vien
                db.NhanViens.Remove(nhanVien);
                db.SaveChanges();

                TempData["Message"] = "Xóa thành công.";
            }
            else
            {
                TempData["Message"] = "Không tìm thấy nhân viên.";
            }

            return RedirectToAction("DanhSachNhanVien", "HomeAdmin");
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

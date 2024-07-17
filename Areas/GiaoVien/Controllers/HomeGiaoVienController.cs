using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Areas.GiaoVien.Models;
using WebQLHS.Models;

namespace WebQLHS.Areas.GiaoVien.Controllers
{
	[Area("giaovien")]
	[Route("giaovien")]
	[Route("giaovien/homegiaovien")]
	public class HomeGiaoVienController : Controller
	{
		QLHS_1Context db = new QLHS_1Context();

		[Route("")]
		[Route("index")]
		public IActionResult Index()
		{
			return View();
		}

		//Xem danh sach hoc sinh theo ma chu nhiem
		[Route("danhsachhocsinhlopchunhiem")]
		[HttpGet]
		public IActionResult DanhSachHocSinhLopChuNhiem()
		{
			TempData["Message"] = "";

			string maNV = HttpContext.Session.GetString("MaNV");

			if (!string.IsNullOrEmpty(maNV))
			{
				var nhanVien = db.NhanViens
					.Include(nv => nv.MaLopHocNavigation)
					.ThenInclude(lh => lh.HocSinhs)
					.FirstOrDefault(nv => nv.MaNv == maNV);

				if (nhanVien != null)
				{
					var hocSinhs = nhanVien.MaLopHocNavigation?.HocSinhs?.ToList() ?? new List<HocSinh>();

					var viewModel = new DanhSachHocSinhViewModel
					{
						NhanVienViewModel = nhanVien,
						HocSinhViewModel = hocSinhs
					};

					return View(viewModel);
				}
				else
				{
					TempData["Message"] = "Không tìm thấy giáo viên.";
					return RedirectToAction("Index", "homegiaovien");
				}

			}
			return View();
		}
        //nhap diem
        [Route("nhapdiem")]
        public IActionResult NhapDiem()
        {
            return View();
        }

        [Route("nhapdiem")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhapDiem(NhapDiemHocSinhViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bangDiem = db.BangDiems
                    .FirstOrDefault(b => b.MaHs == model.MaHs && b.MaMh == model.MaMh);

                if (bangDiem == null)
                {
                    bangDiem = new BangDiem
                    {
                        MaBangDiem = model.MaBangDiem,
                        MaHs = model.MaHs,
                        MaMh = model.MaMh
                    };

                    LogValidationErrors();
                    db.BangDiems.Add(bangDiem);
                }

                var manv = HttpContext.Session.GetString("MaNV");
                if (string.IsNullOrEmpty(manv))
                {
                    ModelState.AddModelError("", "Cannot find the current employee ID in the session.");
                    return View(model);
                }

                var nhapDiem = new NhapDiem
                {
                    MaNhapDiem = Guid.NewGuid().ToString().Substring(0, 15),
                    DiemSo = model.DiemSo,
                    MaMh = model.MaMh,
                    MaNv = manv, // Actual current employee ID from session
                    MaBangDiem = bangDiem.MaBangDiem
                };

                LogValidationErrors();
                db.NhapDiems.Add(nhapDiem);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            LogValidationErrors();
            return View(model);
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


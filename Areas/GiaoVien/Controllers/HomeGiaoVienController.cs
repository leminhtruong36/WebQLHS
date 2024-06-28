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
	}
}


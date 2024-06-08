using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Models;

namespace WebQLHS.Controllers
{
	public class HocSinhController : Controller
	{
		private readonly QlhsDbContext _context;

		public HocSinhController(QlhsDbContext context)
		{
			_context = context;
		}

		//lay danh sach hoc sinh
		public async Task<IActionResult> DanhSachHocSinh()
		{
			var hocSinh = await _context.HocSinh.ToListAsync();
			return View(hocSinh);
		}

		//xem chi tiet hoc sinh
		[Route("HocSinh/Details/{id}")]
		public async Task<IActionResult> Details(String? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			var hocSinh = await _context.HocSinh.FindAsync(id);
			if (hocSinh == null)
			{
				return NotFound();
			}
            return View(hocSinh);
		}

		//Edit Hoc Sinh
		public async Task<IActionResult> Edit(string id)
		{
			var hocSinh = await _context.HocSinh.FindAsync(id);
			if (hocSinh == null)
			{
				return NotFound();
			}
			return View(hocSinh);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, [Bind("MaHS,HoTen,GioiTinh,DiaChi,NgaySinh,MaLop,EmailHocSinh,MaBangDiem,MaTK,MaGiaoDich")] HocSinh hocSinh)
		{
			if (id != hocSinh.MaHS)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(hocSinh);
					await _context.SaveChangesAsync();
                }
				catch (DbUpdateConcurrencyException)
				{
					if (!HocSinhExists(hocSinh.MaHS))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction("Details", new { id = hocSinh.MaHS });
			}
			return View(hocSinh);
		}
		private bool HocSinhExists(string id)
		{
			return _context.HocSinh.Any(e => e.MaHS == id);
		}

	}
}

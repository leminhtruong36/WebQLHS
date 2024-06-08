using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Models;

namespace WebQLHS.Controllers
{
	public class BangDiemController : Controller
	{
		private readonly QlhsDbContext _context;
		public BangDiemController(QlhsDbContext context)
		{
			_context = context;
		}
		//Lay danh sach bang diem
		public async Task<IActionResult> DanhSachBangDiem()
		{
			var bangDiem = await _context.BangDiem.ToListAsync();
			return View(model: bangDiem);
		}
        //Lay danh sach bang diem theo MaHS
        [Route("BangDiem/BangDiem_HocSinh/{maHS}")]
        public async Task<IActionResult> BangDiem_HocSinh(string maHS)
		{
			if (string.IsNullOrEmpty(maHS))
			{
				return NotFound();
			}

			var bangDiemList = await _context.BangDiem
				.Where(bd => bd.MaHocSinh == maHS)
				.ToListAsync();

			if (bangDiemList == null || !bangDiemList.Any())
			{
				return NotFound();
			}

			return View(bangDiemList);
		}
		//xem chi tiet bang diem
		public class BangDiemViewModel
		{
			public string MaBangDiem { get; set; }
			public string MaHocSinh { get; set; }
			public string HocKy { get; set; }
			public double DiemToan { get; set; }
			public double DiemLy { get; set; }
			public double DiemHoa { get; set; }
			public double DiemVan { get; set; }
			public double DiemNgoaiNgu { get; set; }

		}

		[Route("HocSinh/DetailsBangDiem/{id}")]
		public async Task<IActionResult> DetailsBangDiem(String? id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			var bangDiem = await _context.BangDiem.FindAsync(id);
			if (bangDiem == null)
			{
				return NotFound();
			}

			var bangDiemViewModel = new BangDiemViewModel
			{
				MaBangDiem = bangDiem.MaBangDiem,
				MaHocSinh = bangDiem.MaHocSinh,
				HocKy = bangDiem.HocKy,
				DiemToan = bangDiem.DiemToan,
				DiemLy = bangDiem.DiemLy,
				DiemHoa = bangDiem.DiemHoa,
				DiemVan = bangDiem.DiemVan,
				DiemNgoaiNgu = bangDiem.DiemNgoaiNgu
			};

			return View(bangDiemViewModel);
		}

	}
}

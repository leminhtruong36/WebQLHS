using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebQLHS.Models;
using WebQLHS.Models.Authentication;

namespace WebQLHS.Controllers
{
    [Authentication]
    public class LopHocController : Controller
	{
		private readonly QLHS_1Context _context;

		public LopHocController(QLHS_1Context context)
		{
			_context = context;
		}

		public async Task<IActionResult> DanhSachLopHoc()
		{
			var lopHocs = await _context.Lops.ToListAsync();
			return View(lopHocs);
		}

        // GET: LopHoc/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.Lops
                .FirstOrDefaultAsync(m => m.MaLopHoc == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }
    }
}

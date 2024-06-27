using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Models;
using WebQLHS.Models.Authentication;

namespace WebQLHS.Controllers
{

    //[Route("hocsinh")]   
    public class HocSinhController : Controller
    {
        private readonly QLHS_1Context _context;
        public HocSinhController(QLHS_1Context context)
        {
            _context = context;
        }
        public IActionResult DanhSachHocSinh()
        {
            return View();
        }
        [Route("thongtincanhan")]
        [HttpGet]
        public IActionResult ThongTinCaNhan()
        {
            string maHS = HttpContext.Session.GetString("MaHs");
            
            if (!string.IsNullOrEmpty(maHS))
            {
                var hocSinh = _context.HocSinhs
                .FirstOrDefault(hs => hs.MaHs == maHS);

                if (hocSinh == null)
                {
                    return NotFound();
                }
                return View(hocSinh);
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}

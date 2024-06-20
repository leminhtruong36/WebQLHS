using Microsoft.AspNetCore.Mvc;

namespace WebQLHS.Controllers
{
    public class HocSinhController : Controller
    {
        public IActionResult DanhSachHocSinh()
        {
            return View();
        }
    }
}

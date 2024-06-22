using Microsoft.AspNetCore.Mvc;
using WebQLHS.Models.Authentication;

namespace WebQLHS.Controllers
{
    [Authentication]
    public class HocSinhController : Controller
    {
        public IActionResult DanhSachHocSinh()
        {
            return View();
        }
    }
}

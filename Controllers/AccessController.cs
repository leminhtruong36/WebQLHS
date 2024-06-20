using Microsoft.AspNetCore.Mvc;
using WebQLHS.Models;

namespace WebQLHS.Controllers
{
    public class AccessController : Controller
    {
        QLHS_1Context db = new QLHS_1Context();
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(TaiKhoan user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.TaiKhoans.Where(x => x.Email.Equals(user.Email) && x.Mk.Equals(user.Mk)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Email.ToString().Trim());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}

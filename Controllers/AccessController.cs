using Microsoft.AspNetCore.Mvc;
using WebQLHS.Models;
using WebQLHS.Models.Authentication;


namespace WebQLHS.Controllers
{
    public class AccessController : Controller
    {
        QLHS_1Context db = new QLHS_1Context();
        //Login
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
                var checkRoles = db.TaiKhoans.Where(x => x.Email.Equals(user.Email) && x.Mk.Equals(user.Mk) && x.LoaiTaiKhoan.Equals("Admin")).FirstOrDefault();
                if (checkRoles != null)
                {
                    HttpContext.Session.SetString("Username", checkRoles.Email.ToString().Trim());
                    HttpContext.Session.SetString("Role", checkRoles.LoaiTaiKhoan.ToString().Trim());
                    return RedirectToAction("index", "homeadmin", new { area = "admin" });
                }

                var checkRoleGV = db.TaiKhoans.Where(x => x.Email.Equals(user.Email) && x.Mk.Equals(user.Mk) && x.LoaiTaiKhoan.Equals("GiaoVien")).FirstOrDefault();
                if (checkRoleGV != null)
                {
                    HttpContext.Session.SetString("Username", checkRoleGV.Email.ToString().Trim());
                    HttpContext.Session.SetString("Role", checkRoleGV.LoaiTaiKhoan.ToString().Trim());
                    HttpContext.Session.SetString("MaNV", checkRoleGV.Ma.ToString().Trim());
                    return RedirectToAction("index", "homegiaovien", new { area = "giaovien" });
                }
                var checkHS = db.TaiKhoans.Where(x => x.Email.Equals(user.Email) && x.Mk.Equals(user.Mk) && x.LoaiTaiKhoan.Equals("HocSinh")).FirstOrDefault();
                if (checkHS != null)
                {
                    HttpContext.Session.SetString("Username", checkHS.Email.ToString().Trim());
                    HttpContext.Session.SetString("Role", checkHS.LoaiTaiKhoan.ToString().Trim());
                    HttpContext.Session.SetString("MaHs", checkHS.Ma.ToString().Trim());
                    HttpContext.Session.SetString("MaTk", checkHS.MaTk.ToString().Trim());                   
                    return RedirectToAction("index", "HocSinh");
                }
                var u = db.TaiKhoans.Where(x => x.Email.Equals(user.Email) && x.Mk.Equals(user.Mk)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Email.ToString().Trim());
                    HttpContext.Session.SetString("Role", u.LoaiTaiKhoan.ToString().Trim());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        //Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("Username");
            return RedirectToAction("Login", "Access");
        }
    }
}

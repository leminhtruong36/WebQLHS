using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebQLHS.Models;
using WebQLHS.Models.Authentication;

namespace WebQLHS.Controllers
{

    //[Route("hocsinh")]   
    public class HocSinhController : Controller
    {
        private readonly QLHS_1Context _context;
        private QLHS_1Context db = new QLHS_1Context();
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
        public IActionResult XemLichHoc()
        {
            string maHS = HttpContext.Session.GetString("MaHs");
            var query = from tkb in _context.Tkbs
                        join monHocTkb in _context.MonHocTkbs on tkb.MaTkb equals monHocTkb.MaTkb
                        join monHoc in _context.MonHocs on monHocTkb.MaMh equals monHoc.MaMh
                        join hocSinh in _context.HocSinhs on tkb.MaHs equals hocSinh.MaHs
                        join nhanVien in _context.NhanViens on tkb.MaNv equals nhanVien.MaNv
                        where hocSinh.MaHs == maHS
                        select new ThoiKhoaBieuViewModel
                        {
                            MaTkb = tkb.MaTkb,
                            Thu = tkb.Thu,
                            Tiet = tkb.Tiet,
                            TenHocSinh = hocSinh.HoTen,
                            TenGiaoVien = nhanVien.HoTen,
                            TenMonHoc = monHoc.TenMonHoc
                        };

            var result = query.OrderBy(x => x.Thu).ThenBy(x => x.Tiet).ToList();

            return View(result);
        }
        public IActionResult KetQuaHocTap()
        {
            string maHS = HttpContext.Session.GetString("MaHs");

            // Kiểm tra xem MaHS có tồn tại không
            if (string.IsNullOrEmpty(maHS))
            {
                // Nếu không có MaHS trong session, có thể chuyển hướng đến trang đăng nhập hoặc xử lý khác
                return RedirectToAction("Login", "Access"); // Ví dụ: chuyển hướng đến trang đăng nhập
            }

            // Lấy thông tin điểm của học sinh từ cơ sở dữ liệu
            var bangDiems = _context.BangDiems
                .Where(bd => bd.MaHs == maHS)
                .Include(bd => bd.MaHsNavigation) // Tham chiếu đến bảng HocSinh
                .Include(bd => bd.NhapDiems)
                .ThenInclude(nd => nd.MaMhNavigation) // Tham chiếu đến bảng MonHoc
                .ToList();

            // Tạo ViewModel để truyền dữ liệu vào View
            var viewModel = new DiemHocSinhViewModel
            {
                HoTen = bangDiems.FirstOrDefault().MaHsNavigation.HoTen,
                DiemMonHocs = bangDiems.SelectMany(bd => bd.NhapDiems)
                    .Select(nd => new DiemMonHocViewModel
                    {
                        TenMonHoc = nd.MaMhNavigation.TenMonHoc,
                        DiemSo = nd.DiemSo
                    })
                    .ToList()
            };
            return View(viewModel);
        }

        //tao tkb
        public IActionResult TaoTKB()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TaoTKB(ThoiKhoaBieuCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Create new Tkb object
                var newTkb = new Tkb
                {
                    MaTkb = model.MaTkb,
                    Thu = model.Thu,
                    Tiet = model.Tiet,
                    MaHs = model.MaHs,
                    MaNv = model.MaNv
                };

                // Add new Tkb to database
                db.Tkbs.Add(newTkb);

                // Create new MonHocTkb object
                var newMonHocTkb = new MonHocTkb
                {
                    MaMhTkb = Guid.NewGuid().ToString().Substring(0, 10), // Generate a new GUID for primary key
                    MaMh = model.MaMh,
                    MaTkb = model.MaTkb
                };

                // Add new MonHocTkb to database
                db.MonHocTkbs.Add(newMonHocTkb);

                // Save changes to database
                db.SaveChanges();

                return RedirectToAction("Index"); // Redirect to Index action after successful creation
            }

            // If model state is not valid, return the view with the model to show validation errors
            return View(model);
        }
        //dong hoc phi
        [HttpGet]
        //public IActionResult DongHocPhi()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DongHocPhi(string maHs, string maNv, double soTien, string moTa)
        //{
        //    if (string.IsNullOrEmpty(maHs) || string.IsNullOrEmpty(maNv) || soTien <= 0)
        //    {
        //        ModelState.AddModelError("", "Thông tin đóng học phí không hợp lệ.");
        //        return View();
        //    }

        //    var result = await _thuChiService.DongHocPhiAsync(maHs, maNv, soTien, moTa);
        //    if (result)
        //    {
        //        return RedirectToAction("ThongTinCaNhan");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Đóng học phí thất bại. Vui lòng thử lại.");
        //        return View();
        //    }
        //}

        public IActionResult Index()
        {
            return View();
        }

    }
}

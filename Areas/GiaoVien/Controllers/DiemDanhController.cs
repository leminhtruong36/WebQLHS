using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLHS.Areas.GiaoVien.Models;
using WebQLHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.Data.SqlClient;

namespace WebQLHS.Areas.GiaoVien.Controllers
{
    [Area("giaovien")]
    [Route("giaovien")]
    [Route("giaovien/diemdanh")]
    public class DiemDanhController : Controller
    {
        private readonly QLHS_1Context _context;
        private readonly ILogger<DiemDanhController> _logger;

        public DiemDanhController(QLHS_1Context context, ILogger<DiemDanhController> logger)
        {
            _context = context;
            _logger = logger;
        }
        [HttpGet]
        [Route("index")]
        // Action để hiển thị form điểm danh
        public IActionResult Index()
        {
            // Lấy danh sách các lớp để người dùng chọn
            var lopList = _context.Lops.ToList();
            ViewBag.LopList = new SelectList(lopList, "MaLopHoc", "MaLopHoc");

            return View();
        }
        [HttpPost]
        [Route("check")]
        public IActionResult Check(string maLopHoc, DateTime ngayDiemDanh)
        {
            // Lấy danh sách học sinh của lớp được chọn
            var hocSinhs = _context.HocSinhs.Where(hs => hs.MaLopHoc == maLopHoc).ToList();

            // Trả về view để điểm danh với danh sách học sinh và ngày được chọn
            ViewBag.NgayDiemDanh = ngayDiemDanh;
            return View(hocSinhs);
        }

        [HttpPost]
        [Route("luudiemdanh")]
        public IActionResult LuuDiemDanh(List<string> maHsList, DateTime ngayDiemDanh, List<bool?> coPhepList, List<bool?> khongPhepList)
        {
            // Kiểm tra xem danh sách học sinh có hợp lệ hay không
            if (maHsList == null || maHsList.Count == 0)
            {
                _logger.LogWarning("Danh sách học sinh không hợp lệ hoặc trống.");
                return BadRequest("Danh sách học sinh không hợp lệ.");
            }

            // Nếu coPhepList hoặc khongPhepList là null, khởi tạo danh sách mới với độ dài tương đương maHsList
            if (coPhepList == null)
            {
                _logger.LogInformation("coPhepList là null, khởi tạo danh sách mới.");
                coPhepList = new List<bool?>(new bool?[maHsList.Count]);
            }
            else if (coPhepList.Count < maHsList.Count)
            {
                _logger.LogInformation("coPhepList không đủ phần tử, thêm các phần tử null.");
                coPhepList.AddRange(new bool?[maHsList.Count - coPhepList.Count]);
            }

            if (khongPhepList == null)
            {
                _logger.LogInformation("khongPhepList là null, khởi tạo danh sách mới.");
                khongPhepList = new List<bool?>(new bool?[maHsList.Count]);
            }
            else if (khongPhepList.Count < maHsList.Count)
            {
                _logger.LogInformation("khongPhepList không đủ phần tử, thêm các phần tử null.");
                khongPhepList.AddRange(new bool?[maHsList.Count - khongPhepList.Count]);
            }

            // Đảm bảo tất cả các danh sách có cùng độ dài
            if (maHsList.Count != coPhepList.Count || maHsList.Count != khongPhepList.Count)
            {
                _logger.LogWarning("Độ dài của các danh sách không khớp: maHsList.Count = {maHsListCount}, coPhepList.Count = {coPhepListCount}, khongPhepList.Count = {khongPhepListCount}",
                    maHsList.Count, coPhepList.Count, khongPhepList.Count);
                return BadRequest("Danh sách học sinh và trạng thái điểm danh không cùng độ dài.");
            }

            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    for (int i = 0; i < maHsList.Count; i++)
                    {
                        string maHs = maHsList[i];
                        bool coPhep = coPhepList[i] ?? false;
                        bool khongPhep = khongPhepList[i] ?? false;

                        _logger.LogInformation("Xử lý điểm danh cho học sinh: MaHs = {maHs}, NgayDiemDanh = {ngayDiemDanh}, CoPhep = {coPhep}, KhongPhep = {khongPhep}",
                            maHs, ngayDiemDanh, coPhep, khongPhep);

                        try
                        {
                            var diemDanh = _context.DiemDanh.FirstOrDefault(dd => dd.MaHs == maHs && dd.Ngay == ngayDiemDanh);
                            if (diemDanh != null)
                            {
                                diemDanh.CoPhep = coPhep;
                                diemDanh.TrangThai = true;
                            }
                            else
                            {
                                diemDanh = new DiemDanh
                                {
                                    MaDiemDanh = Guid.NewGuid().ToString(), // Tạo mã điểm danh mới
                                    MaHs = maHs,
                                    Ngay = ngayDiemDanh,
                                    CoPhep = coPhep,
                                    TrangThai = true,
                                    GhiChu = null
                                };
                                _context.DiemDanh.Add(diemDanh);
                            }

                            _context.SaveChanges();
                            _logger.LogInformation("Đã lưu điểm danh cho học sinh: MaHs = {maHs}, NgayDiemDanh = {ngayDiemDanh}", maHs, ngayDiemDanh);
                        }
                        catch (DbUpdateException ex)
                        {
                            _logger.LogError(ex, "Có lỗi xảy ra khi xử lý điểm danh cho học sinh: MaHs = {maHs}, NgayDiemDanh = {ngayDiemDanh}", maHs, ngayDiemDanh);

                            // Kiểm tra lỗi truncate dữ liệu
                            if (ex.InnerException is SqlException sqlEx && sqlEx.Number == 2628)
                            {
                                // Xử lý lỗi truncate dữ liệu
                                _logger.LogError("Lỗi truncate dữ liệu trong cột MaDiemDanh. Giá trị mã điểm danh có thể quá dài.");
                                TempData["ErrorMessage"] = "Có lỗi xảy ra khi lưu điểm danh. Vui lòng thử lại sau.";
                                return RedirectToAction("Index", "HomeGiaoVien");
                            }
                            else
                            {
                                // Xử lý các ngoại lệ khác
                                throw;
                            }
                        }
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi cho người dùng
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi lưu điểm danh. Vui lòng thử lại sau.";
                return RedirectToAction("Index", "HomeGiaoVien");
            }

            return RedirectToAction("Index", "Home");
        }
        // Log error
        private void LogValidationErrors()
        {
            foreach (var key in ModelState.Keys)
            {
                var state = ModelState[key];
                foreach (var error in state.Errors)
                {
                    // Log each validation error
                    Console.WriteLine($"Error for {key}: {error.ErrorMessage}");
                }
            }
        }
    }
}

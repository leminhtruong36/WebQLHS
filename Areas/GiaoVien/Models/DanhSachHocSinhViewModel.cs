using WebQLHS.Models;

namespace WebQLHS.Areas.GiaoVien.Models
{
    public class DanhSachHocSinhViewModel
    {
        public NhanVien NhanVienViewModel { get; set; }
        public List<HocSinh> HocSinhViewModel { get; set; }
    }
}

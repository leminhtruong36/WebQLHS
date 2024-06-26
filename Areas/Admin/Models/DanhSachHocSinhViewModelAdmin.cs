using WebQLHS.Models;

namespace WebQLHS.Areas.Admin.Models
{
    public class DanhSachHocSinhViewModelAdmin
    {
        public NhanVien NhanVienViewModel { get; set; }
        public List<HocSinh> HocSinhViewModel { get; set; }
    }
}

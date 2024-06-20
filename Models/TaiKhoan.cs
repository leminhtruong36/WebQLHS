using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            HocSinhs = new HashSet<HocSinh>();
        }

        public string MaTk { get; set; } = null!;
        public string Mk { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LoaiTaiKhoan { get; set; } = null!;
        public string MaNv { get; set; } = null!;

        public virtual NhanVien MaNvNavigation { get; set; } = null!;
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
    }
}

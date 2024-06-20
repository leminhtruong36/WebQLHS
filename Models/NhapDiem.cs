using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class NhapDiem
    {
        public string MaNhapDiem { get; set; } = null!;
        public double DiemSo { get; set; }
        public string MaMh { get; set; } = null!;
        public string MaNv { get; set; } = null!;
        public string MaBangDiem { get; set; } = null!;

        public virtual BangDiem MaBangDiemNavigation { get; set; } = null!;
        public virtual MonHoc MaMhNavigation { get; set; } = null!;
        public virtual NhanVien MaNvNavigation { get; set; } = null!;
    }
}

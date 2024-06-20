using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class BaiTap
    {
        public string MaBaiTap { get; set; } = null!;
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MaNv { get; set; } = null!;
        public string MaLopHoc { get; set; } = null!;

        public virtual Lop MaLopHocNavigation { get; set; } = null!;
        public virtual NhanVien MaNvNavigation { get; set; } = null!;
    }
}

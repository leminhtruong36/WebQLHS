using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class ThuChi
    {
        public string MaGiaoDich { get; set; } = null!;
        public string LoaiGiaoDich { get; set; } = null!;
        public DateTime NgayGiaoDich { get; set; }
        public double SoTien { get; set; }
        public string MoTa { get; set; } = null!;
        public string MaHs { get; set; } = null!;
        public string MaNv { get; set; } = null!;

        public virtual HocSinh MaHsNavigation { get; set; } = null!;
        public virtual NhanVien MaNvNavigation { get; set; } = null!;
    }
}

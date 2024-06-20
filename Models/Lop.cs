using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class Lop
    {
        public Lop()
        {
            BaiTaps = new HashSet<BaiTap>();
            HocSinhs = new HashSet<HocSinh>();
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaLopHoc { get; set; } = null!;
        public string TenLop { get; set; } = null!;
        public int SiSo { get; set; }

        public virtual ICollection<BaiTap> BaiTaps { get; set; }
        public virtual ICollection<HocSinh> HocSinhs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}

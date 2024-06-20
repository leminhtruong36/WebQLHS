using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class Tkb
    {
        public Tkb()
        {
            MonHocTkbs = new HashSet<MonHocTkb>();
        }

        public string MaTkb { get; set; } = null!;
        public string Thu { get; set; } = null!;
        public string Tiet { get; set; } = null!;
        public string MaHs { get; set; } = null!;
        public string MaNv { get; set; } = null!;

        public virtual HocSinh MaHsNavigation { get; set; } = null!;
        public virtual NhanVien MaNvNavigation { get; set; } = null!;
        public virtual ICollection<MonHocTkb> MonHocTkbs { get; set; }
    }
}

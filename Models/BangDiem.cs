using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class BangDiem
    {
        public BangDiem()
        {
            NhapDiems = new HashSet<NhapDiem>();
        }

        public string MaBangDiem { get; set; } = null!;
        public string MaHs { get; set; } = null!;
        public string MaMh { get; set; } = null!;

        public virtual HocSinh MaHsNavigation { get; set; } = null!;
        public virtual MonHoc MaMhNavigation { get; set; } = null!;
        public virtual ICollection<NhapDiem> NhapDiems { get; set; }
    }
}

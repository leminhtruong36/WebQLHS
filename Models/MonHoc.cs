using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            BangDiems = new HashSet<BangDiem>();
            MonHocTkbs = new HashSet<MonHocTkb>();
            NhapDiems = new HashSet<NhapDiem>();
        }

        public string MaMh { get; set; } = null!;
        public string TenMonHoc { get; set; } = null!;

        public virtual ICollection<BangDiem> BangDiems { get; set; }
        public virtual ICollection<MonHocTkb> MonHocTkbs { get; set; }
        public virtual ICollection<NhapDiem> NhapDiems { get; set; }
    }
}

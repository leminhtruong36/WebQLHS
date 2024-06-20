using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class ChucVu
    {
        public string MaCv { get; set; } = null!;
        public string TenChucVu { get; set; } = null!;
        public string MaNv { get; set; } = null!;

        public virtual NhanVien MaNvNavigation { get; set; } = null!;
    }
}

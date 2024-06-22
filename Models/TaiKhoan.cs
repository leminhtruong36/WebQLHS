using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            HocSinhs = new HashSet<HocSinh>();
            NhanViens = new HashSet<NhanVien>();
        }

        public string MaTk { get; set; } = null!;
        public string Mk { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string LoaiTaiKhoan { get; set; } = null!;

        public virtual ICollection<HocSinh> HocSinhs { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}

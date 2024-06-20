using System;
using System.Collections.Generic;

namespace WebQLHS.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            BaiTaps = new HashSet<BaiTap>();
            ChucVus = new HashSet<ChucVu>();
            NhapDiems = new HashSet<NhapDiem>();
            ThuChis = new HashSet<ThuChi>();
            Tkbs = new HashSet<Tkb>();
        }

        public string MaNv { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public DateTime NgaySinh { get; set; }
        public string HoTen { get; set; } = null!;
        public string MaLopHoc { get; set; } = null!;
        public string MaTk { get; set; } = null!;

        public virtual Lop MaLopHocNavigation { get; set; } = null!;
        public virtual TaiKhoan MaTkNavigation { get; set; } = null!;
        public virtual ICollection<BaiTap> BaiTaps { get; set; }
        public virtual ICollection<ChucVu> ChucVus { get; set; }
        public virtual ICollection<NhapDiem> NhapDiems { get; set; }
        public virtual ICollection<ThuChi> ThuChis { get; set; }
        public virtual ICollection<Tkb> Tkbs { get; set; }
    }
}

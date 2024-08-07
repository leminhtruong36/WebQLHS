﻿namespace WebQLHS.Models
{
    public partial class HocSinh
    {
        public HocSinh()
        {
            BangDiems = new HashSet<BangDiem>();
            ThuChis = new HashSet<ThuChi>();
            Tkbs = new HashSet<Tkb>();
            DiemDanhs = new HashSet<DiemDanh>();
        }

        public string MaHs { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string GioiTinh { get; set; } = null!;
        public string DiaChi { get; set; } = null!;
        public DateTime NgaySinh { get; set; }
        public string EmailHocSinh { get; set; } = null!;
        public string MaLopHoc { get; set; } = null!;
        public string MaTk { get; set; } = null!;

        public virtual Lop MaLopHocNavigation { get; set; } = null!;
        public virtual TaiKhoan MaTkNavigation { get; set; } = null!;
        public virtual ICollection<DiemDanh> DiemDanhs { get; set; }
        public virtual ICollection<BangDiem> BangDiems { get; set; }
        public virtual ICollection<ThuChi> ThuChis { get; set; }
        public virtual ICollection<Tkb> Tkbs { get; set; }
    }
}

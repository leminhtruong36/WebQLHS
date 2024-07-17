using System;
using System.Collections.Generic;

namespace WebQLHS.Areas.GiaoVien.Models
{
    public class DiemDanhViewModel
    {
        public string MaLopHoc { get; set; }
        public DateTime NgayDiemDanh { get; set; }
        public List<HocSinhDiemDanh> HocSinhs { get; set; }
    }
    public class HocSinhDiemDanh
    {
        public string MaHs { get; set; }
        public string HoTen { get; set; }
        public bool? VangCoPhep { get; set; }
        public bool? VangKhongPhep { get; set; }
    }
}

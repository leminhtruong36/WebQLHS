using System;
using System.Collections.Generic;

namespace WebQLHS.Areas.GiaoVien.Models
{
    public class DiemDanhViewModel
    {
        public string MaHs { get; set; }
        public string HoTen { get; set; }
        public bool TrangThai { get; set; }
        public string GhiChu { get; set; }
    }
    public class DiemDanhListViewModel
    {
        public string MaLopHoc { get; set; }
        public DateTime Ngay { get; set; }
        public List<DiemDanhViewModel> DiemDanhList { get; set; }
    }
}

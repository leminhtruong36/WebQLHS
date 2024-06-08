using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebQLHS.Models
{
    public class HocSinh
    {
        public string MaHS { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string MaLop { get; set; }
        public string EmailHocSinh { get; set; }
        public string MaTK { get; set; }
        public string MaGiaoDich { get; set; }
        public virtual BangDiem BangDiem { get; set; }
    }
}

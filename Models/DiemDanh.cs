using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQLHS.Models
{
    public partial class DiemDanh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string MaDiemDanh { get; set; }
        public string MaHs { get; set; }
        public DateTime Ngay { get; set; }
        public bool TrangThai { get; set; }
        public bool CoPhep { get; set; }
        public string GhiChu { get; set; }

        public virtual HocSinh HocSinh { get; set; }
    }
}

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

        [Required]
        public string MaHs { get; set; }

        [Required]
        public DateTime Ngay { get; set; }

        [Required]
        public bool TrangThai { get; set; }

        public string? GhiChu { get; set; }

        [ForeignKey("MaHs")]
        public virtual HocSinh HocSinh { get; set; }
    }
}

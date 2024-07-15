namespace WebQLHS.Models
{
    public class DiemHocSinhViewModel
    {
        public string HoTen { get; set; }
        public List<DiemMonHocViewModel> DiemMonHocs { get; set; }
    }

    public class DiemMonHocViewModel
    {
        public string TenMonHoc { get; set; }
        public double DiemSo { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Data
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }

        public string TenLop { get; set; }
        public DateTime NamNhapHoc { get; set; }
        public DateTime NamRaTruong { get; set; }
        public int SoLuongSV { get; set; }

  
    }
}

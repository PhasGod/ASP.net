using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_01.Models
{
    public class PhongBan
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int SoLuongnv { get; set; }
        [Required]
        public int PhongBanQL { get; set; }
    }
}

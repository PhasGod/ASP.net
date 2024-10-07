using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiKiemTra03_01.Models
{
    public class NhanVien
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public DateTime HireDate { get; set; } = DateTime.Now;
        public PhongBan PhongBan { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace BaiTap07a.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
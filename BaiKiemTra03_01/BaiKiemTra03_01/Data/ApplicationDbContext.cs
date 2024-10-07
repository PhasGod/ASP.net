using BaiKiemTra03_01.Controllers;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NhanVien = BaiKiemTra03_01.Models.NhanVien;

namespace BaiKiemTra03_01.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<NhanVien> NhanVien { get; set; }
        public DbSet<PhongBan> PhongBan { get; set; }
    }
}

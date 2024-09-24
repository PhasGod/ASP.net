using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using projectA.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    public class SanPhamController : Controller
        
    {
        private readonly ApplicationDbContext _db;
        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("Theloai").ToList();
            return View(sanpham);
        }
    }
}

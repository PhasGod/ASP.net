using Microsoft.AspNetCore.Mvc;
using projectA.Data;

namespace projectA.Models
{
    public class Sort : Controller
    {
        private readonly ApplicationDbContext _db;

        public Sort(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult FillterBySanPham(int id, string sort)
        {
            var products = _db.SanPham.AsQueryable();

            if (id > 0)
            {
                products = products.Where(p => p.TheLoaiId == id);
            }
            // Kiểm tra tham số sort và sắp xếp danh sách
            if (!string.IsNullOrEmpty(sort))
            {
                products = products.OrderBy(p => p.price);
            }
            else if (sort == "desc")
            {
                products = products.OrderByDescending(p => p.price);
            }

            return View(products.ToList());
        }
    }
}

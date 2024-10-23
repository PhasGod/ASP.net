using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using projectA.Data;
using projectA.Models;

namespace projectA.Controllers
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
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }
        [HttpGet]
        public IActionResult Upsert(int id)
            {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.TheLoai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
            );
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0) //create/insert
            {
                return View(sanpham);
            }
            else
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }
          }    

        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
           if (ModelState.IsValid)
             {
                if (sanpham.Id == 0)
                    {
                        // Thêm thông tin vào bảng TheLoai
                        _db.SanPham.Add(sanpham);
                    }
                else
                    {
                        _db.SanPham.Update(sanpham);
                    }
                
                    // Lưu lại
                     _db.SaveChanges();
                 // Chuyển trang về index
                    return RedirectToAction("Index");
                }
                return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {                     
                var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
                if (sanpham == null)
                {
                    return NotFound();
                }
                _db.SanPham.Remove(sanpham);
                _db.SaveChanges();
                return Json(new { success = true });
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var sanpham = _db.SanPham.Find(id);
            return View(sanpham);
        }
       
    }
}

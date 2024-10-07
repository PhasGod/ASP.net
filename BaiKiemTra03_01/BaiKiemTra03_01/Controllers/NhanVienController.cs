using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_01.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NhanVienController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var nhanvien = _db.NhanVien.ToList();
            ViewBag.NhanVien = nhanvien;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.NhanVien.Add(nhanvien);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhanvien = _db.NhanVien.Find(id);
            return View(nhanvien);
        }

        [HttpPost]
        public IActionResult Edit(NhanVien nhanvien)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.NhanVien.Update(nhanvien);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhanvien = _db.NhanVien.Find(id);
            return View(nhanvien);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var nhanvien = _db.NhanVien.Find(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            _db.NhanVien.Remove(nhanvien);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhanvien = _db.NhanVien.Find(id);
            return View(nhanvien);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // Sử dụng LinQ để tìm kiếm
                var nhanvien = _db.NhanVien
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();
                ViewBag.searchString = searchString;
                ViewBag.Nhanvien = nhanvien;
            }
            else
            {
                var nhanvien = _db.NhanVien.ToList();
                ViewBag.NhanVien = nhanvien;
            }
            return View("Index"); // Sử  dụng lại View Index
        }
    }
}

using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_01.Controllers
{
    public class PhongBanController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PhongBanController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var phongban = _db.PhongBan.ToList();
            ViewBag.PhongBan = phongban;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PhongBan phongban)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.PhongBan.Add(phongban);
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
            var phongban = _db.PhongBan.Find(id);
            return View(phongban);
        }

        [HttpPost]
        public IActionResult Edit(PhongBan phongban)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.PhongBan.Update(phongban);
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
            var phongban = _db.PhongBan.Find(id);
            return View(phongban);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var phongban = _db.PhongBan.Find(id);
            if (phongban == null)
            {
                return NotFound();
            }
            _db.PhongBan.Remove(phongban);
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
            var phongban = _db.PhongBan.Find(id);
            return View(phongban);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                // Sử dụng LinQ để tìm kiếm
                var phongban = _db.PhongBan
                    .Where(tl => tl.Name.Contains(searchString))
                    .ToList();
                ViewBag.searchString = searchString;
                ViewBag.PhongBan = phongban;
            }
            else
            {
                var phongban = _db.PhongBan.ToList();
                ViewBag.PhongBan =   phongban;
            }
            return View("Index"); // Sử  dụng lại View Index
        }
    }
}

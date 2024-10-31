using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectA.Data;
using projectA.Models;

namespace projectA.Controllers
{
    [Area("Admin")]
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DonHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<HoaDon> hoadon = _db.HoaDon.Include("ApplicationUser").ToList();
            return View(hoadon);
        }

        [HttpGet]
        // GET: HoaDon/Delete/5
        public IActionResult Delete(int id)
        {
            var hoaDon = _db.HoaDon.FirstOrDefault(h => h.Id == id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDon/DeleteConfirmed/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var hoaDon = _db.HoaDon.Find(id);
            if (hoaDon == null)
            {
                return NotFound();
            }
            _db.HoaDon.Remove(hoaDon);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

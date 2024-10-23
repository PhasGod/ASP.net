using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectA.Data;
using projectA.Models;
using System.Security.Claims;

namespace projectA.Controllers
{
    [Area("Customer")]
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GioHangController(ApplicationDbContext db)
        {  _db = db; }

		[Authorize]
		public IActionResult Index()
        {
            //Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            //Lay danh sach san pham trong gio hang cua User
            //  IEnumerable<GioHang> dsGioHang = _db.GioHang
            //   .Include("SanPham")
            //  .Where(gh => gh.ApplicationUserId == claim.Value)
            // .ToList();
            // return View(dsGioHang);
            GioHangViewModel giohang = new GioHangViewModel
            {
                DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };
            foreach (var item in giohang.DsGioHang)
            {
                double productprice = item.Quantity * item.SanPham.price;
                giohang.HoaDon.Total += productprice;
            }
            return View(giohang);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Xoa(int giohangId)
        {
            var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            _db.GioHang.Remove(giohang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

		[HttpGet]
		[Authorize]
		public IActionResult Tang(int giohangId)
		{
			var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            giohang.Quantity += 1; //Tang so luong len 1

			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize]
		public IActionResult Giam(int giohangId)
		{
			var giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
			giohang.Quantity -= 1; //Giam so luong di 1

            if(giohang.Quantity ==0) // Neu so luong = 0 thi xoa san pham
            {
                _db.GioHang.Remove(giohang);
            }
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

        
        [Authorize]
        public IActionResult ThanhToan()
        {
            //Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            GioHangViewModel giohang = new GioHangViewModel()
            {
                DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };
            // Tim thong tin tai khoan trong CSDL de hien thi len trang tahnh toan 
            giohang.HoaDon.ApplicationUser = _db.ApplicationUser.FirstOrDefault(user => user.Id == claim.Value);
            // Gan thong tin tai khoan vao hoa don
            giohang.HoaDon.Name = giohang.HoaDon.ApplicationUser.Name;
            giohang.HoaDon.Address = giohang.HoaDon.ApplicationUser.Address;
            giohang.HoaDon.PhoneNumber = giohang.HoaDon.ApplicationUser.PhoneNumber;

            foreach (var item in giohang.DsGioHang)
            {
                double productprice = item.Quantity * item.SanPham.price;
                giohang.HoaDon.Total += productprice;
            }
            return View(giohang);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ThanhToan(GioHangViewModel giohang)
        {
            //Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // GioHangViewModel giohang = new GioHangViewModel()
            // {
            giohang.DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList();
           //     HoaDon = new HoaDon()
            //};
            // Tim thong tin tai khoan trong CSDL de hien thi len trang tahnh toan 
            giohang.HoaDon.ApplicationUser = _db.ApplicationUser.FirstOrDefault(user => user.Id == claim.Value);
            // Gan thong tin tai khoan vao hoa don
            giohang.HoaDon.ApplicationUserId = claim.Value;
            giohang.HoaDon.OrderDate = DateTime.Now;
            giohang.HoaDon.OrderStatus = "Đang xác nhận";

            foreach (var item in giohang.DsGioHang)
            {
                double productprice = item.Quantity * item.SanPham.price;
                giohang.HoaDon.Total += productprice;
            }
            _db.HoaDon.Add(giohang.HoaDon);
            _db.SaveChanges();

            foreach (var item in giohang.DsGioHang)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon()
                {
                    SanPhamId = item.SanPhamId,
                    HoaDonId = giohang.HoaDon.Id,
                    ProductPrice = item.SanPham.price,
                    Quantity = item.Quantity
                };
                _db.ChiTietHoaDon.Add(chitiethoadon);
                _db.SaveChanges();
            }
            _db.GioHang.RemoveRange(giohang.DsGioHang);
            _db.SaveChanges();

            return View("Index", "Home");
        }
    }
}

using BaiTap06.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap06.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult DangKy(TaiKhoanViewModel taiKhoan)
        {
            //if (taikhoan != null && taikhoan.Password !=null && (taikhoan.Password).Length>0)
            //{
            //    taikhoan.Password = taikhoan.Password + "_chuoi_ma_hoa";
            //}

            return View(taiKhoan);
        }
      
    }
}

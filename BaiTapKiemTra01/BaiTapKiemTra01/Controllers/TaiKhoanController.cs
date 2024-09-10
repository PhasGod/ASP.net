using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
	public class TaiKhoanController : Controller
	{
		public IActionResult TaiKhoan(TaiKhoanViewModel model)
		{
            if (model.Username != null)
            {
				return Content(model.Username);
            }
            return View();
		}
	}
}

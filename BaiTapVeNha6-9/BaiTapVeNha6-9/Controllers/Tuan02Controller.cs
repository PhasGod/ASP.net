using Microsoft.AspNetCore.Mvc;

namespace BaiTapVeNha6_9.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = " Lê Mai Minh Trọng";
            ViewBag.MSSV = "1822040869";
            ViewBag.Nam = @DateTime.Now.Year;

            return View();
        }
    }
}

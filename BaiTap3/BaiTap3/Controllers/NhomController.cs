using Microsoft.AspNetCore.Mvc;

namespace BaiTap03.Controllers
{
    public class NhomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
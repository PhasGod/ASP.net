using BaiTapVeNha6_9.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BaiTapVeNha6_9.Controllers
{
    public class MayTinhController : Controller
    {
        public IActionResult Index()
        {
            
            var model = new MayTinhModel
            {
                a = 5,
                b = 4,
                pheptinh = "tru"               
            };
            switch (model.pheptinh)
            {
                case "nhan":
                    ViewBag.Ketqua = model.a * model.b;
                    break;
                case "chia":
                    ViewBag.Ketqua = model.b != 0 ? model.a / model.b : double.NaN;
                    break;
                case "cong":
                    ViewBag.Ketqua = model.a + model.b;
                    break;
                case "tru":
                    ViewBag.Ketqua = model.a - model.b;
                    break;
                default:
                    break;
            }

            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectA.Data;
using projectA.Models;
namespace projectA.ViewComponents
{
	public class TheLoaiViewComponent : ViewComponent
	{
		private readonly ApplicationDbContext _db;
		public TheLoaiViewComponent(ApplicationDbContext db)
		{
			_db = db;
		}
		public IViewComponentResult Invoke()
		{
			var theloai = _db.TheLoai.ToList();
			return View(theloai);
		}

		
	}
}

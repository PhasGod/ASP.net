using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectA.Data;
using projectA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectA.ViewComponents
{
	public class GiaTienViewComponent : ViewComponent
	{
		private readonly ApplicationDbContext _db;

		public GiaTienViewComponent(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<IViewComponentResult> InvokeAsync(string sortOrder = "asc")
		{
			// Lấy danh sách sản phẩm từ cơ sở dữ liệu
			var giatien = await _db.SanPham.ToListAsync();

			// Sắp xếp sản phẩm theo giá tiền
			if (sortOrder == "asc")
			{
				giatien = giatien.OrderBy(p => p.price).ToList();
			}
			else if (sortOrder == "desc")
			{
				giatien = giatien.OrderByDescending(p => p.price).ToList();
			}

			// Trả về View với danh sách sản phẩm đã sắp xếp
			return View(giatien);
		}
	}
}

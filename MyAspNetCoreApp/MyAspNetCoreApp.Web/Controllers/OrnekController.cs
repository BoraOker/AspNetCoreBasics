using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
	public class Product2
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	public class OrnekController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.name = "Asp.Net Core";
			// ViewBag.name = new List<string>() = {"ahmet","mehmet","ayse"};		Best Practice değil!

			ViewData["age"] = 35;
			ViewData["names"] = new List<string>() {"ahmet","mehmet","remzi"};

			ViewBag.person = new {Id = 1, Name = "Bora", Age = 20};

			TempData["surname"] = "Işın";       // Bir action methottan farklı bir action'ın cshtml sayfasına veri taşımak için TempData kullanırız.

			var ProductList = new List<Product2>()
			{
				new() {Id =  1, Name = "Ada"},
				new() {Id = 2, Name = "Eylül"},
				new() {Id = 3,Name = "Rıza"}

			};

			return View(ProductList);				// Hacimli verileri taşımak için bu şekilde ViewModel kullanılır.
		}

		public IActionResult Index2()
		{
			var surName = TempData["surname"];		// TempData ile bir action methottaki veriyi başka bir action methoda da taşıyabiliriz.


            return View();
		}
		
		public IActionResult Index3()
		{
			return RedirectToAction("Index","Ornek");
		}

		public IActionResult ParametreView(int id)
		{
			return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });
		}
		public IActionResult JsonResultParametre(int id)
		{
			return Json(new { id = id});
		}

		public IActionResult ContentResult()
		{
			return Content("content result");
		}

		public IActionResult JsonResult()
		{
			return Json(new { id = 1, name = "kalem", price = 20 });
		}

		public IActionResult EmptyResult()
		{
			return new EmptyResult();
		}
	}
}

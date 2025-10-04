using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;

        private readonly ProductRepository _productRepository;

        public ProductsController(AppDbContext context) 
        {
            _productRepository = new ProductRepository();

            _context = context;
            
        } 

        public IActionResult Index()
        {
            var products = _context.Products.ToList();

            return View(products);
        }

        public IActionResult Remove(int id)
        {
            _productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add() 
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Context;

namespace SimpleCRM.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p =>
            p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
        

    }
}

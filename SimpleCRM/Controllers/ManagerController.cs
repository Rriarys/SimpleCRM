using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Context;
using SimpleCRM.Models;

namespace SimpleCRM.Controllers
{
    public class ManagerController : Controller
    {
        private readonly AppDbContext _context;

        public ManagerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u =>
                u.Username == username && u.Password == password && u.IsManager);

            if (user == null)
            {
                ViewBag.Message = "Неверный логин или пароль";
                return View();
            }

            return RedirectToAction("Index", "Manager");
        }

        public IActionResult Index()
        {
            // Страница для управления товарами
            var products = _context.Products.ToList();
            return View(products);
        }
    }
}

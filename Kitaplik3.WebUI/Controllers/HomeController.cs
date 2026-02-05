using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using Kitaplik3.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Kitaplik3.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookManager _bookManager;
        private readonly CategoryManager _categoryManager;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _bookManager = new BookManager();
            _categoryManager = new CategoryManager();
        }

        public IActionResult Index()
        {
            // Son eklenen 6 kitabý getir (carousel için)
            List<Book> featuredBooks = _bookManager.GetWithAll()
                .OrderByDescending(b => b.Id)
                .Take(6)
                .ToList();

            ViewBag.FeaturedBooks = featuredBooks;

            // Ýstatistikler için
            ViewBag.TotalBooks = _bookManager.GetAll().Count;
            ViewBag.TotalCategories = _categoryManager.GetAll().Count;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
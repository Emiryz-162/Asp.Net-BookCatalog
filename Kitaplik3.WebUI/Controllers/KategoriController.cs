using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Kitaplik3.WebUI.Controllers
{
    public class KategoriController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();

        [HttpGet]
        public IActionResult Kategoriler()
        {
            List<Category> categories = _categoryManager.GetAll();
            ViewBag.KategorilerBag = categories;
            return View(new Category());
        }

        [HttpPost]
        [Authorize]
        public IActionResult KategoriEkle(Category c)
        {
            _categoryManager.Add(c);
            return RedirectToAction(nameof(Kategoriler));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Sil(int id)
        {
            var kategori = _categoryManager.GetById(id);

            if (kategori != null)
            {
                _categoryManager.Delete(kategori);
            }

            return RedirectToAction(nameof(Kategoriler));
        }

        [Authorize]
        public IActionResult KategoriGuncelle(int id)
        {
            Category kategori = _categoryManager.GetById(id);
            return View(kategori);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Guncelle(Category c)
        {
            if (c != null)
            {
                _categoryManager.Update(c);
            }
            return RedirectToAction(nameof(Kategoriler));
        }
    }
}

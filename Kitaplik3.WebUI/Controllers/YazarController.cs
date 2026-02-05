using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik3.WebUI.Controllers
{
    public class YazarController : Controller
    {
        AuthorManager _AuthorManager = new();

        [HttpGet]
        public IActionResult Yazarlar()
        {
            List<Author> Yazarlar = _AuthorManager.GetAll();
            ViewBag.YazarlarBag = Yazarlar;
            return View(new Author());
        }

        [HttpPost]
        [Authorize]
        public IActionResult YazarEkle(Author a)
        {
            _AuthorManager.Add(a);
            return RedirectToAction(nameof(Yazarlar));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Sil(int id)
        {
            var author = _AuthorManager.GetById(id);
            _AuthorManager.Delete(author);

            return RedirectToAction(nameof(Yazarlar));
        }

        [HttpGet]
        [Authorize]
        public IActionResult YazarGuncelle(int id)
        {
            var author = _AuthorManager.GetById(id);
            return View(author);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Guncelle(Author a)
        {
            _AuthorManager.Update(a);

            return RedirectToAction(nameof(Yazarlar));
        }
    }
}

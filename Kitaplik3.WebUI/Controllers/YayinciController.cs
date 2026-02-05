using Kitaplik3.Business.Concrete;
using Kitaplik3.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik3.WebUI.Controllers
{
    [Authorize]
    public class YayinciController : Controller
    {
        PublisherManager _publisherManager = new();

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Yayincilar()
        {
            List<Publisher> publishers = _publisherManager.GetAll();
            ViewBag.PublisherBag = publishers;
            return View(new Publisher());
        }

        [HttpPost]
        public IActionResult YayincilarEkle(Publisher p)
        {
            _publisherManager.Add(p);
            return RedirectToAction(nameof(Yayincilar));
        }


        [HttpPost]
        public IActionResult Sil(int id)
        {
            var kategori = _publisherManager.GetById(id);

            if (kategori != null)
            {
                _publisherManager.Delete(kategori);
            }

            return RedirectToAction(nameof(Yayincilar));
        }

        public IActionResult YayinciGuncelle(int id)
        {
            Publisher yayinci = _publisherManager.GetById(id);
            return View(yayinci);
        }

        [HttpPost]
        public IActionResult Guncelle(Publisher p)
        {
            if (p != null)
            {
                _publisherManager.Update(p);
            }

            return RedirectToAction(nameof(Yayincilar));
        }
    }
}

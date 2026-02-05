using Kitaplik3.Business.Concrete;
using Kitaplik3.Business.Validators;
using Kitaplik3.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace Kitaplik3.WebUI.Controllers
{
    public class KitapController : Controller
    {
        BookManager _BookManager = new();
        CategoryManager _CategoryManager = new();
        AuthorManager _AuthorManager = new();
        PublisherManager _PublisherManager = new();

        private readonly IWebHostEnvironment _env;

        public KitapController(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IActionResult Kitaplar()
        {
            List<Book> Books = _BookManager.GetWithAll();
            return View(Books);
        }

        [HttpGet]
        [Authorize]
        public IActionResult KitapEkle()
        {
            List<Category> Categories = _CategoryManager.GetAll();
            ViewBag.KategoriBag = new SelectList(Categories, "Id", "Name");

            List<Author> authors = _AuthorManager.GetAll();
            ViewBag.YazarBag = new SelectList(authors, "Id", "Name");

            List<Publisher> publisher = _PublisherManager.GetAll();
            ViewBag.YayinciBag = new SelectList(publisher, "Id", "Name");

            return View(new Book());
        }

        [HttpPost]
        [Authorize]
        public IActionResult KitapEkle(Book b, IFormFile foto)
        {
            // ÖNEMLİ: Navigation property'leri ModelState'den kaldır
            // Çünkü form sadece ID'leri gönderiyor, navigation property'ler NULL geliyor
            ModelState.Remove("Category");
            ModelState.Remove("Author");
            ModelState.Remove("Publisher");

            // Validation kontrolü (şimdi sadece ID'ler ve diğer alanlar kontrol edilecek)
            if (!ModelState.IsValid)
            {
                // ViewBag'leri tekrar doldur
                ViewBag.KategoriBag = new SelectList(_CategoryManager.GetAll(), "Id", "Name", b.CategoryId);
                ViewBag.YazarBag = new SelectList(_AuthorManager.GetAll(), "Id", "Name", b.AuthorId);
                ViewBag.YayinciBag = new SelectList(_PublisherManager.GetAll(), "Id", "Name", b.PublisherId);

                return View(b);
            }

            // Foto yükleme
            if (foto != null && foto.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "img", "books");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    foto.CopyTo(stream);
                }

                b.FotoUrl = "/img/books/" + fileName;
            }

            _BookManager.Add(b);
            return RedirectToAction(nameof(Kitaplar));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Sil(int id)
        {
            Book b = _BookManager.GetById(id);
            _BookManager.Delete(b);
            return RedirectToAction(nameof(Kitaplar));
        }

        [HttpGet]
        [Authorize]
        public IActionResult KitapGuncelle(int id)
        {
            Book b = _BookManager.GetById(id);

            List<Category> Categories = _CategoryManager.GetAll();
            ViewBag.KategoriBag = new SelectList(Categories, "Id", "Name", b.CategoryId);

            List<Author> authors = _AuthorManager.GetAll();
            ViewBag.YazarBag = new SelectList(authors, "Id", "Name", b.AuthorId);

            List<Publisher> publisher = _PublisherManager.GetAll();
            ViewBag.YayinciBag = new SelectList(publisher, "Id", "Name", b.PublisherId);

            return View(b);
        }

        [HttpPost]
        [Authorize]
        public IActionResult KitapGuncelle(Book b, IFormFile foto)
        {
            // Navigation property'leri ModelState'den kaldır
            ModelState.Remove("Category");
            ModelState.Remove("Author");
            ModelState.Remove("Publisher");
            ModelState.Remove("IsDelete"); // ← BUNU EKLE
            ModelState.Remove("foto"); // ← BUNU EKLE

            if (!ModelState.IsValid)
            {
                ViewBag.KategoriBag = new SelectList(_CategoryManager.GetAll(), "Id", "Name", b.CategoryId);
                ViewBag.YazarBag = new SelectList(_AuthorManager.GetAll(), "Id", "Name", b.AuthorId);
                ViewBag.YayinciBag = new SelectList(_PublisherManager.GetAll(), "Id", "Name", b.PublisherId);

                return View(b);
            }

            // Foto yükleme
            if (foto != null && foto.Length > 0)
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "img", "books");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(foto.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    foto.CopyTo(stream);
                }

                b.FotoUrl = "/img/books/" + fileName;
            }

            // IsDelete false olarak ayarla (güncelleme sırasında silinmemeli)
            b.IsDelete = false;

            _BookManager.Update(b);
            return RedirectToAction(nameof(Kitaplar));
        }
    }
}
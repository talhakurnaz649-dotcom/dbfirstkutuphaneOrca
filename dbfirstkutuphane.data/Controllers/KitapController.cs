using dbfirstkutuphane;
using dbfirstkutuphane.Models;
using dbfirstkutuphane.data.Filters;
using Microsoft.AspNetCore.Mvc;

namespace dbfirstkutuphane.data.Controllers
{
    [GirisGerekli]
    public class KitapController : Controller
    {
        private readonly KutuphaneContext _context = new();

        public IActionResult Index()
        {
            var kitaplar = _context.Kitaplar.ToList();
            return View(kitaplar);
        }

        [AdminGerekli]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminGerekli]
        public IActionResult Create(Kitaplar kitap)
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [AdminGerekli]
        public IActionResult Edit(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null) return NotFound();
            return View(kitap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminGerekli]
        public IActionResult Edit(Kitaplar kitap)
        {
            _context.Kitaplar.Update(kitap);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [AdminGerekli]
        public IActionResult Delete(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null) return NotFound();
            return View(kitap);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminGerekli]
        public IActionResult DeleteConfirmed(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
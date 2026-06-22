using dbfirstkutuphane;
using dbfirstkutuphane.Models;
using dbfirstkutuphane.data.Filters;
using Microsoft.AspNetCore.Mvc;

namespace dbfirstkutuphane.data.Controllers
{
    [AdminGerekli]
    public class UyeController : Controller
    {
        private readonly KutuphaneContext _context = new();

        public IActionResult Index()
        {
            var uyeler = _context.Uyeler.ToList();
            return View(uyeler);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Uyeler uye)
        {
            _context.Uyeler.Add(uye);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var uye = _context.Uyeler.Find(id);
            if (uye == null) return NotFound();
            return View(uye);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Uyeler uye)
        {
            _context.Uyeler.Update(uye);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var uye = _context.Uyeler.Find(id);
            if (uye == null) return NotFound();
            return View(uye);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var uye = _context.Uyeler.Find(id);
            if (uye != null)
            {
                _context.Uyeler.Remove(uye);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
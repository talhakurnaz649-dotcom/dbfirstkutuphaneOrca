using dbfirstkutuphane;
using dbfirstkutuphane.Models;
using dbfirstkutuphane.data.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dbfirstkutuphane.data.Controllers
{
    [GirisGerekli]
    public class OduncController : Controller
    {
        private readonly KutuphaneContext _context = new();

        public IActionResult Index()
        {
            var query = _context.OduncIslemleri
                .Include(o => o.Kitap)
                .Include(o => o.Uye)
                .AsQueryable();

            if (HttpContext.Session.GetString("Rol") == "User")
            {
                var uyeId = HttpContext.Session.GetInt32("UyeId");
                if (uyeId.HasValue && uyeId > 0)
                    query = query.Where(o => o.UyeId == uyeId);
            }

            return View(query.ToList());
        }

        public IActionResult Create(int? kitapId)
        {
            var rol = HttpContext.Session.GetString("Rol");
            var uyeId = HttpContext.Session.GetInt32("UyeId");

            ViewBag.KitapId = new SelectList(_context.Kitaplar.Where(k => k.Stok > 0), "KitapId", "Ad", kitapId);
            ViewBag.Rol = rol;

            if (rol == "User" && uyeId.HasValue)
            {
                ViewBag.UyeId = uyeId;
                ViewBag.UyeAd = _context.Uyeler.Find(uyeId)?.Ad;
            }
            else
            {
                ViewBag.UyeId = new SelectList(_context.Uyeler, "UyeId", "Ad");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OduncIslemleri odunc)
        {
            var rol = HttpContext.Session.GetString("Rol");
            if (rol == "User")
            {
                var uyeId = HttpContext.Session.GetInt32("UyeId");
                if (uyeId.HasValue) odunc.UyeId = uyeId.Value;
            }

            var kitap = _context.Kitaplar.Find(odunc.KitapId);
            if (kitap == null || kitap.Stok <= 0)
            {
                ViewBag.Hata = "Bu kitap stokta yok!";
                ViewBag.KitapId = new SelectList(_context.Kitaplar, "KitapId", "Ad", odunc.KitapId);
                ViewBag.Rol = rol;
                if (rol == "User")
                    ViewBag.UyeId = odunc.UyeId;
                else
                    ViewBag.UyeId = new SelectList(_context.Uyeler, "UyeId", "Ad", odunc.UyeId);
                return View(odunc);
            }

            odunc.OduncTarihi = DateTime.Now;
            kitap.Stok--;
            _context.OduncIslemleri.Add(odunc);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [AdminGerekli]
        public IActionResult Edit(int id)
        {
            var odunc = _context.OduncIslemleri.Find(id);
            if (odunc == null) return NotFound();

            ViewBag.KitapId = new SelectList(_context.Kitaplar, "KitapId", "Ad", odunc.KitapId);
            ViewBag.UyeId = new SelectList(_context.Uyeler, "UyeId", "Ad", odunc.UyeId);
            return View(odunc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminGerekli]
        public IActionResult Edit(OduncIslemleri odunc)
        {
            _context.OduncIslemleri.Update(odunc);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [AdminGerekli]
        public IActionResult Delete(int id)
        {
            var odunc = _context.OduncIslemleri
                .Include(o => o.Kitap)
                .Include(o => o.Uye)
                .FirstOrDefault(o => o.OduncId == id);
            if (odunc == null) return NotFound();
            return View(odunc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminGerekli]
        public IActionResult DeleteConfirmed(int id)
        {
            var odunc = _context.OduncIslemleri.Find(id);
            if (odunc != null)
            {
                _context.OduncIslemleri.Remove(odunc);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

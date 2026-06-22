using dbfirstkutuphane;
using dbfirstkutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace dbfirstkutuphane.data.Controllers
{
    public class GirisController : Controller
    {
        private readonly KutuphaneContext _context = new();

        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "talha" && sifre == "1234")
            {
                HttpContext.Session.SetString("Rol", "Admin");
                HttpContext.Session.SetString("KullaniciAdi", "talha");
                return RedirectToAction("Index", "Home");
            }

            var kullanici = _context.Kullanicilar
                .FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);

            if (kullanici != null)
            {
                HttpContext.Session.SetString("Rol", "User");
                HttpContext.Session.SetString("KullaniciAdi", kullanici.KullaniciAdi);
                HttpContext.Session.SetInt32("UyeId", kullanici.UyeId ?? 0);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı!";
            return View();
        }

        public IActionResult Kayit()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Rol")))
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Kayit(string kullaniciAdi, string sifre, string sifreTekrar, string ad, string soyad, string? email)
        {
            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                ViewBag.Hata = "Kullanıcı adı ve şifre zorunludur!";
                return View();
            }

            if (sifre != sifreTekrar)
            {
                ViewBag.Hata = "Şifreler eşleşmiyor!";
                return View();
            }

            if (kullaniciAdi.ToLower() == "talha")
            {
                ViewBag.Hata = "Bu kullanıcı adı kullanılamaz!";
                return View();
            }

            if (_context.Kullanicilar.Any(k => k.KullaniciAdi == kullaniciAdi))
            {
                ViewBag.Hata = "Bu kullanıcı adı zaten alınmış!";
                return View();
            }

            var uye = new Uyeler
            {
                Ad = ad,
                Soyad = soyad,
                Email = email
            };
            _context.Uyeler.Add(uye);
            _context.SaveChanges();

            var kullanici = new Kullanicilar
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre,
                Ad = ad,
                Soyad = soyad,
                Email = email,
                KayitTarihi = DateTime.Now,
                UyeId = uye.UyeId
            };
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();

            HttpContext.Session.SetString("Rol", "User");
            HttpContext.Session.SetString("KullaniciAdi", kullanici.KullaniciAdi);
            HttpContext.Session.SetInt32("UyeId", uye.UyeId);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

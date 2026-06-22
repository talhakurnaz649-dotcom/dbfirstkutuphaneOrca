using System.Diagnostics;
using dbfirstkutuphane.data.Filters;
using dbfirstkutuphane.data.Models;
using Microsoft.AspNetCore.Mvc;

namespace dbfirstkutuphane.data.Controllers
{
    [GirisGerekli]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string filbBasligi = "Mucize Uğur Böceği İle Kara Kedi";
            string filmYonetmen = "Alex";
            string filmAciklama = "Film Açıklaması";
            string[] filmOyuncular = { "Marinette", "Adrien Agreste" };

            ViewBag.FilmBasligi = filbBasligi;
            ViewBag.FilmYönetmen = filmYonetmen;
            ViewBag.FilmAciklamasi = filmAciklama;
            ViewBag.Oyuncular = filmOyuncular;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}

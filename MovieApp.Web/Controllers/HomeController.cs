using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Model;

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
            string filmUrl = "1.jpg";

            var m = new Movie();
            m.Title = filbBasligi;
            m.Description = filmAciklama;
            m.Director = filmYonetmen;
            m.Players = filmOyuncular;
            m.ImageUrl = filmUrl;

            return View(m);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}

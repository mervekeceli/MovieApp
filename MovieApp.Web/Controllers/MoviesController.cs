using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Model;
using System.Collections.Generic;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //localhost:5000/movies/list
        public IActionResult List()
        {
            var filmListesi = new List<Movie>() { 
                new Movie{Title = "Film 1", Description= "Aciklama 1", Director="Yönetmen 1", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "1.jpg"},
                new Movie{Title = "Film 2", Description= "Aciklama 2", Director="Yönetmen 2", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "2.jpg"},
                new Movie{Title = "Film 3", Description= "Aciklama 3", Director="Yönetmen 3", Players=new string[] {"Oyuncu1", "Oyuncu2", "Oyuncu3"}, ImageUrl = "3.jpg"}

            };

            var turler = new List<Genre>() { 
                new Genre{Name="Macera"},
                new Genre{Name="Komedi"},
                new Genre{Name="Romantik"},
                new Genre{Name="Bilim Kurgu"},
            };

            var model = new MovieGenreViewModel()
            {
                Movies = filmListesi,
                Genres = turler
            };

            return View("Movies",model);
        }


        //localhost:5000/movies/details
        public IActionResult Details()
        {
            return View();
        }
    }
}

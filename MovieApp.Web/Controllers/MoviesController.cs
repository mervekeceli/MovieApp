using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //localhost:5000/movies/list
        //localhost:5000/movies/list/1
        [HttpGet]
        public IActionResult List(int? id, string q)
        {
            var movies = MovieRepository.Movies;
            if (id != null)
            {
                movies = movies.Where(x => x.GenreId == id).ToList();
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower())).ToList();
            }

            var model = new MoviesViewModel()
            {
                Movies = movies
            };

            return View("Movies", model);
        }


        //localhost:5000/movies/details
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(MovieRepository.GetById(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                //Model Binding
                MovieRepository.Add(movie);
                return RedirectToAction("List"); // Action'a yönlendirme
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(MovieRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            if (ModelState.IsValid)
            {
                MovieRepository.Edit(movie);
                // /movies/details/1
                return RedirectToAction("Details", "Movies", new { @id = movie.MovieId });
            }
            ViewBag.Genres = new SelectList(GenreRepository.Genres, "GenreId", "Name");
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(int MovieId, string Title)
        {
            MovieRepository.Delete(MovieId);
            TempData["Message"] = $"{Title} isimli film silindi";
            return RedirectToAction("List");
        }
    }
}

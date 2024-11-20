using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Entity;
using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;
        public MoviesController(MovieContext movieContext)
        {
            _context = movieContext;
        }

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
            //var movies = MovieRepository.Movies;

            var movies = _context.Movies.AsQueryable();
            if (id != null)
            {
                movies = movies
                    .Include(m=>m.Genres)
                    .Where(x => x.Genres.Any(g=>g.GenreId == id));
            }

            if (!string.IsNullOrEmpty(q))
            {
                movies = movies.Where(m => m.Title.ToLower().Contains(q.ToLower()) ||
                m.Description.ToLower().Contains(q.ToLower()));
            }

            var model = new MoviesViewModel()
            {
                Movies = movies.ToList()
            };

            return View("Movies", model);
        }


        //localhost:5000/movies/details
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Movies.Find(id));
        }        
    }
}

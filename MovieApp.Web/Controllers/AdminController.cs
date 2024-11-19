using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApp.Web.Data;
using MovieApp.Web.Model;
using System.Linq;

namespace MovieApp.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly MovieContext _context; //Injection işlemi
        public AdminController(MovieContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieUpdate(int? id)
        {
            if (id == null)
                return NotFound();

            var entity = _context.Movies.Select(m => new AdminEditMovieViewModel
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                ImageUrl = m.ImageUrl,
            }).FirstOrDefault(m=>m.MovieId == id);

            if (entity == null)
                return NotFound();

            return View(entity);
        }

        [HttpPost]
        public IActionResult MovieUpdate(AdminEditMovieViewModel model)
        {
            var entity = _context.Movies.Find(model.MovieId);
            if(entity == null)
                return NotFound();

            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageUrl = model.ImageUrl;

            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies
                .Include(m => m.Genres)
                //.Select(x=> new AdminMovieViewModel
                //{
                //    MovieId = x.MovieId,
                //    Title = x.Title,
                //    ImageUrl = x.ImageUrl,
                //    Genres = x.Genres.ToList()
                //})
                .ToList()
            });
        }
    }
}

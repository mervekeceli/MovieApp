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

        public IActionResult MovieList()
        {
            return View(new AdminMoviesViewModel
            {
                Movies = _context.Movies
                .Include(m => m.Genres)
                .ToList()
            });
        }
    }
}

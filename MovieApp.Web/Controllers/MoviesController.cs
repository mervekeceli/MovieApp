using Microsoft.AspNetCore.Mvc;

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
            return View("Movies");
        }


        //localhost:5000/movies/details
        public IActionResult Details()
        {
            return View();
        }
    }
}

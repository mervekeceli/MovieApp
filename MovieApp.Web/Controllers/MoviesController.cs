using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Web.Controllers
{
    public class MoviesController : Controller
    {
        //localhost:5000/movies/list
        public IActionResult List()
        {
            return View();
        }


        //localhost:5000/movies/details
        public IActionResult Details()
        {
            return View();
        }
    }
}

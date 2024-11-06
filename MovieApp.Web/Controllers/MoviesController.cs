using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
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
            


            var model = new MoviesViewModel()
            {
                Movies = MovieRepository.Movies
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

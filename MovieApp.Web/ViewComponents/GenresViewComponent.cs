using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Web.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly MovieContext _context;
        public GenresViewComponent(MovieContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData.Values["id"];
            return View(_context.Genres.ToList());
        }
    }
}

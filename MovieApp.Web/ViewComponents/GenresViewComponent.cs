using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Data;
using MovieApp.Web.Model;
using System.Collections.Generic;

namespace MovieApp.Web.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(GenreRepository.Genres);
        }
    }
}

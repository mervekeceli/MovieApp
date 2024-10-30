using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Model;
using System.Collections.Generic;

namespace MovieApp.Web.ViewComponents
{
    public class GenresViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var turler = new List<Genre>() {
                new Genre{Name="Macera"},
                new Genre{Name="Komedi"},
                new Genre{Name="Romantik"},
                new Genre{Name="Bilim Kurgu"},
            };

            return View(turler);
        }
    }
}

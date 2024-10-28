using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Ana Sayfa";
        }

        public string About()
        {
            return "hakkımızda";
        }
    }
}

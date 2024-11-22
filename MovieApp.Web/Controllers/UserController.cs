using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Model;

namespace MovieApp.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel model)
        {
            return View();
        }
    }
}

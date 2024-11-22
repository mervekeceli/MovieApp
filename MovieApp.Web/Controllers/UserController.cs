using Microsoft.AspNetCore.Mvc;
using MovieApp.Web.Model;
using System.Collections.Generic;
using System.Linq;

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

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerifyUserName(string UserName)
        {
            var users = new List<string> { "mervekeceli", "berkantalperen" };

            if (users.Any(x => x == UserName))
            {
                return Json($"{UserName} isimli kullanıcı adı daha önce alınmış!");
            }
            return Json(true);
        }
    }
}

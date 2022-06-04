using Microsoft.AspNetCore.Mvc;
using Tutorial.UI.ViewModel;

namespace Tutorial.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View(model);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(AppUserViewModel model)
        {
            return View(model);
        }
    }
}

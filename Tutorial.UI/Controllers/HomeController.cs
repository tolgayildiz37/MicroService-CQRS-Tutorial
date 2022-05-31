using Microsoft.AspNetCore.Mvc;

namespace Tutorial.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

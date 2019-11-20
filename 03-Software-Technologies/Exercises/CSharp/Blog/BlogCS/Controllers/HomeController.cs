using Microsoft.AspNetCore.Mvc;

namespace BlogCS.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

namespace FDMC.Controllers
{
    using FDMC.Services;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly ICatService catService;

        public HomeController(ICatService catService)
        {
            this.catService = catService;
        }

        public IActionResult Index()
        {
            return this.View(this.catService.GetAll());
        }
    }
}

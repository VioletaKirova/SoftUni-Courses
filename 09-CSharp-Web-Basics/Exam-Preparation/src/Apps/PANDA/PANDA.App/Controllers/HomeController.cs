namespace PANDA.App.Controllers
{
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Identity;
    using SIS.MvcFramework.Result;

    public class HomeController : Controller
    {
        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                Principal model = this.User;

                return IndexLoggedIn(model);
            }

            return this.View();
        }

        [NonAction]
        public IActionResult IndexLoggedIn(Principal model)
        {
            return this.View(model);
        }
    }
}

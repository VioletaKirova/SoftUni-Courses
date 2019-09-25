namespace Panda.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Panda.App.Models.Packages;
    using Panda.Data;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly PandaDbContext dbContext;

        public HomeController(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var packages = this.dbContext.Packages
                    .Where(package => package.Recipient.UserName == this.User.Identity.Name)
                    .Include(package => package.Status)
                    .Select(package => new PackageHomeViewModel
                    {
                        Id = package.Id,
                        Description = package.Description,
                        Status = package.Status.Name
                    })
                    .ToList();

                return this.View(packages);
            }

            return this.View();
        }
    }
}

namespace PANDA.App.Controllers
{
    using PANDA.App.ViewModels.Packages;
    using PANDA.Models;
    using PANDA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    public class PackagesController : Controller
    {
        private readonly IPackageService packageService;

        private readonly IUserService userService;

        public PackagesController(IPackageService packageService, IUserService userService)
        {
            this.packageService = packageService;
            this.userService = userService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View(this.userService.GetAllUsernames());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(PackageCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Packages/Create");
            }

            User recipient = this.userService.GetUserByUsername(model.RecipientName);

            Package package = new Package
            {
                Description = model.Description,
                Weight = model.Weight,
                ShippingAddress = model.ShippingAddress,
                RecipientId = recipient.Id
            };

            this.packageService.CreatePackage(package);

            return this.Redirect("/Packages/Pending");
        }

        [Authorize]
        public IActionResult Pending()
        {
            var pendingPackages = this.packageService.GetPendingPackages();

            var model = new PackageAllOutputModel();

            foreach (var pendingPackage in pendingPackages)
            {
                model.Packages.Add(new PackageOutputModel
                {
                    Id = pendingPackage.Id,
                    Description = pendingPackage.Description,
                    Weight = pendingPackage.Weight,
                    ShippingAddress = pendingPackage.ShippingAddress,
                    RecipientName = pendingPackage.Recipient.Username
                });
            }

            return this.View(model);
        }

        [Authorize]
        public IActionResult Delivered()
        {
            var deliveredPackages = this.packageService.GetDeliveredPackages();

            var model = new PackageAllOutputModel();

            foreach (var deliveredPackage in deliveredPackages)
            {
                model.Packages.Add(new PackageOutputModel
                {
                    Id = deliveredPackage.Id,
                    Description = deliveredPackage.Description,
                    Weight = deliveredPackage.Weight,
                    ShippingAddress = deliveredPackage.ShippingAddress,
                    RecipientName = deliveredPackage.Recipient.Username
                });
            }

            return this.View(model);
        }

        [Authorize]
        public IActionResult Deliver(PackageDeliverInputModel model)
        {
            this.packageService.DeliverPackage(model.Id, this.User.Id);

            return this.Redirect("/Packages/Pending");
        }
    }
}

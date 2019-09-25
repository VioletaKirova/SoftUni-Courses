namespace Panda.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Panda.App.Models.Packages;
    using Panda.Data;
    using Panda.Domain;
    using System;
    using System.Globalization;
    using System.Linq;

    public class PackagesController : Controller
    {
        private readonly PandaDbContext dbContext;

        public PackagesController(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            this.ViewData["Recipients"] = this.dbContext.Users.ToList();

            return this.View(new PackageCreateBindingModel());
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(PackageCreateBindingModel bindingModel)
        {
            this.ViewData["Recipients"] = this.dbContext.Users.ToList();

            if (!this.ModelState.IsValid)
            {
                return this.View(bindingModel ?? new PackageCreateBindingModel());
            }

            Package package = new Package
            {
                Description = bindingModel.Description,
                Weight = bindingModel.Weight,
                ShippingAddress = bindingModel.ShippingAddress,
                Recipient = this.dbContext.Users.SingleOrDefault(user => user.UserName == bindingModel.Recipient),
                Status = this.dbContext.PackageStatuses.SingleOrDefault(status => status.Name == "Pending")
            };

            this.dbContext.Packages.Add(package);
            this.dbContext.SaveChanges();

            return this.Redirect("/Packages/Pending");
        }

        [HttpGet("/Packages/Ship/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Ship(string id)
        {
            var package = this.dbContext.Packages.Find(id);
            package.Status = this.dbContext.PackageStatuses.SingleOrDefault(status => status.Name == "Shipped");
            package.EstimatedDeliveryDate = DateTime.Now.AddDays(new Random().Next(20, 40));

            this.dbContext.Update(package);
            this.dbContext.SaveChanges();

            return this.Redirect("/Packages/Shipped");
        }

        [HttpGet("/Packages/Deliver/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Deliver(string id)
        {
            var package = this.dbContext.Packages.Find(id);
            package.Status = this.dbContext.PackageStatuses.SingleOrDefault(status => status.Name == "Delivered");

            this.dbContext.Update(package);
            this.dbContext.SaveChanges();

            return this.Redirect("/Packages/Delivered");
        }

        [HttpGet("/Packages/Acquire/{id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {
            var package = this.dbContext.Packages.Find(id);
            package.Status = this.dbContext.PackageStatuses.SingleOrDefault(status => status.Name == "Acquired");
            this.dbContext.Update(package);

            var receipt = new Receipt
            {
                Fee = (decimal)(package.Weight * 2.67),
                IssuedOn = DateTime.UtcNow,
                Recipient = this.dbContext.Users.SingleOrDefault(user => user.UserName == this.User.Identity.Name),
                Package = package
            };

            this.dbContext.Receipts.Add(receipt);
            this.dbContext.SaveChanges();

            return this.Redirect("/Home/Index");
        }

        [HttpGet("/Packages/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            var package = this.dbContext.Packages
                .Where(packageFromDB => packageFromDB.Id == id)
                .Include(packageFromDB => packageFromDB.Recipient)
                .Include(packageFromDB => packageFromDB.Status)
                .SingleOrDefault();

            var viewModel = new PackageDetailsViewModel
            {
                ShippingAddress = package.ShippingAddress,
                Status = package.Status.Name,
                Weight = package.Weight,
                Recipient = package.Recipient.UserName,
                Description = package.Description
            };

            if (package.Status.Name == "Pending")
            {
                viewModel.EstimatedDeliveryDate = "N/A";
            }
            else if (package.Status.Name == "Shipped")
            {
                viewModel.EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else if (package.Status.Name == "Delivered" || package.Status.Name == "Acquired")
            {
                viewModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Pending()
        {
            return this.View(this.dbContext.Packages
                .Include(package => package.Recipient)
                .Where(package => package.Status.Name == "Pending")
                .ToList()
                .Select(package => new PackagePendingViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    Weight = package.Weight,
                    ShippingAddress = package.ShippingAddress,
                    Recipient = package.Recipient.UserName
                })
                .ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delivered()
        {
            return this.View(this.dbContext.Packages
                .Include(package => package.Recipient)
                .Where(package => package.Status.Name == "Delivered" || package.Status.Name == "Acquired")
                .ToList()
                .Select(package => new PackageDeliveredViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    Weight = package.Weight,
                    ShippingAddress = package.ShippingAddress,
                    Recipient = package.Recipient.UserName
                })
                .ToList());
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Shipped()
        {
            return this.View(this.dbContext.Packages
                .Include(package => package.Recipient)
                .Where(package => package.Status.Name == "Shipped")
                .ToList()
                .Select(package => new PackageShippedViewModel
                {
                    Id = package.Id,
                    Description = package.Description,
                    Weight = package.Weight,
                    EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Recipient = package.Recipient.UserName
                })
                .ToList());
        }
    }
}

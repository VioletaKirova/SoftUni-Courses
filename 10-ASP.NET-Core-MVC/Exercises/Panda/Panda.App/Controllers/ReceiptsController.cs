namespace Panda.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Panda.App.Models.Receipts;
    using Panda.Data;
    using System.Globalization;
    using System.Linq;

    public class ReceiptsController : Controller
    {
        private readonly PandaDbContext dbContext;

        public ReceiptsController(PandaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult My()
        {
            var receipts = this.dbContext.Receipts
                .Where(receipt => receipt.Recipient.UserName == this.User.Identity.Name)
                .Include(receipt => receipt.Recipient)
                .Select(receipt => new ReceiptMyViewModel
                {
                    Id = receipt.Id,
                    Fee = receipt.Fee,
                    IssuedOn = receipt.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Recipient = receipt.Recipient.UserName
                })
                .ToList();

            return this.View(receipts);
        }

        [HttpGet("/Receipts/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            var receiptFromDb = this.dbContext.Receipts
                .Where(receipt => receipt.Id == id)
                .Include(receipt => receipt.Package)
                .Include(receipt => receipt.Recipient)
                .SingleOrDefault();

            var viewModel = new ReceiptDetailsViewModel
            {
                Id = receiptFromDb.Id,
                IssuedOn = receiptFromDb.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                DeliveryAddress = receiptFromDb.Package.ShippingAddress,
                PackageWeight = receiptFromDb.Package.Weight,
                PackageDescription = receiptFromDb.Package.Description,
                Recipient = receiptFromDb.Recipient.UserName,
                Total = receiptFromDb.Fee
            };

            return this.View(viewModel);
        }
    }
}

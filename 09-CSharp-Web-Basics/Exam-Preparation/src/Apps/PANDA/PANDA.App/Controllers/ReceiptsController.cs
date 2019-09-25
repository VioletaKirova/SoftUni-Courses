namespace PANDA.App.Controllers
{
    using PANDA.App.ViewModels.Receipts;
    using PANDA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Result;

    public class ReceiptsController : Controller
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        public IActionResult Index()
        {
            var receipts = this.receiptService.GetAllReceipts(this.User.Id);

            var model = new ReceiptAllOutputModel();

            foreach (var receipt in receipts)
            {
                model.Receipts.Add(new ReceiptOutputModel
                {
                    Id = receipt.Id,
                    Fee = $"${receipt.Fee:f2}",
                    IssuedOn = receipt.IssuedOn?.ToString("dd/MM/yyyy HH:mm"),
                    RecipientName = receipt.Recipient.Username
                });
            }

            return this.View(model);
        }
    }
}

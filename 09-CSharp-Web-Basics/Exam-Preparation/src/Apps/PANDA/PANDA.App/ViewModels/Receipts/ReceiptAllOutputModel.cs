namespace PANDA.App.ViewModels.Receipts
{
    using System.Collections.Generic;

    public class ReceiptAllOutputModel
    {
        public ReceiptAllOutputModel()
        {
            this.Receipts = new List<ReceiptOutputModel>();
        }

        public ICollection<ReceiptOutputModel> Receipts { get; set; }
    }
}

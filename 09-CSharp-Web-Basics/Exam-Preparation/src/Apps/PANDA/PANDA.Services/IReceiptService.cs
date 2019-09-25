namespace PANDA.Services
{
    using PANDA.Models;
    using System.Collections.Generic;

    public interface IReceiptService
    {
        ICollection<Receipt> GetAllReceipts(string id);
    }
}

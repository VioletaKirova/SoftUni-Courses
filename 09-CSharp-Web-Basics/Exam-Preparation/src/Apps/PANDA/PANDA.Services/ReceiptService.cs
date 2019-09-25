namespace PANDA.Services
{
    using Microsoft.EntityFrameworkCore;
    using PANDA.Data;
    using PANDA.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ReceiptService : IReceiptService
    {
        private readonly PandaDbContext dbContext;

        public ReceiptService(PandaDbContext pandaDbContext)
        {
            this.dbContext = pandaDbContext;
        }

        public ICollection<Receipt> GetAllReceipts(string id)
        {
            return this.dbContext.Receipts
                .Include(r => r.Recipient)
                .Where(r => r.RecipientId == id)
                .ToList();
        }
    }
}

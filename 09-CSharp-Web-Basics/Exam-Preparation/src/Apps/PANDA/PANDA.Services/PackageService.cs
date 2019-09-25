namespace PANDA.Services
{
    using Microsoft.EntityFrameworkCore;
    using PANDA.Data;
    using PANDA.Models;
    using PANDA.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PackageService : IPackageService
    {
        private readonly PandaDbContext dbContext;

        public PackageService(PandaDbContext pandaDbContext)
        {
            this.dbContext = pandaDbContext;
        }

        public Package CreatePackage(Package package)
        {
            var packageForDb = this.dbContext.Packages.Add(package).Entity;
            this.dbContext.SaveChanges();

            return packageForDb;

        }

        public void DeliverPackage(string packageId, string userId)
        {
            this.dbContext.Packages
                .SingleOrDefault(p => p.Id == packageId)
                .Status = Status.Delivered;

            this.dbContext.SaveChanges();

            Package deliveredPackage = this.dbContext.Packages
                .SingleOrDefault(p => p.Id == packageId);

            Receipt receipt = new Receipt
            {
                Fee = (decimal)deliveredPackage.Weight * 2.67M,
                IssuedOn = DateTime.UtcNow,
                RecipientId = userId,
                PackageId = packageId
            };

            this.dbContext.Receipts.Add(receipt);
            this.dbContext.SaveChanges();
        }

        public ICollection<Package> GetDeliveredPackages()
        {
            return this.dbContext.Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status == Status.Delivered)
                .ToList();
        }

        public ICollection<Package> GetPendingPackages()
        {
            return this.dbContext.Packages
                .Include(p => p.Recipient)
                .Where(p => p.Status == Status.Pending)
                .ToList();
        }
    }
}

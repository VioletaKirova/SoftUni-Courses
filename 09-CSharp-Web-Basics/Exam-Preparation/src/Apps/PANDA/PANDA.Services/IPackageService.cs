namespace PANDA.Services
{
    using PANDA.Models;
    using System.Collections.Generic;

    public interface IPackageService
    {
        Package CreatePackage(Package package);

        void DeliverPackage(string packageId, string userId);

        ICollection<Package> GetPendingPackages();

        ICollection<Package> GetDeliveredPackages();
    }
}

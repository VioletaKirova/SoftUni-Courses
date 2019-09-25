namespace PANDA.App
{
    using PANDA.Data;
    using PANDA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.DependencyContainer;
    using SIS.MvcFramework.Routing;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (PandaDbContext context = new PandaDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IPackageService, PackageService>();
            serviceProvider.Add<IReceiptService, ReceiptService>();
        }
    }
}

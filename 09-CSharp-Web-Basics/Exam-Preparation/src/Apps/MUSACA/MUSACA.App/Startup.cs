namespace MUSACA.App
{
    using MUSACA.Data;
    using MUSACA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.DependencyContainer;
    using SIS.MvcFramework.Routing;

    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (MusacaDbContext context = new MusacaDbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            serviceProvider.Add<IUserService, UserService>();
            serviceProvider.Add<IOrderService, OrderService>();
            serviceProvider.Add<IProductService, ProductService>();
        }
    }
}

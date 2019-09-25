namespace MUSACA.App.Controllers
{
    using MUSACA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult Cashout()
        {
            string orderId = this.orderService.GetActiveOrder(this.User.Id).Id;

            this.orderService.Cashout(orderId);

            return this.Redirect("/");
        }
    }
}

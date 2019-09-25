namespace MUSACA.App.Controllers
{
    using MUSACA.App.VeiwModels.Orders;
    using MUSACA.App.VeiwModels.Products;
    using MUSACA.Models;
    using MUSACA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Result;
    using System.Linq;

    public class HomeController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IProductService productService;

        public HomeController(IOrderService orderService, IProductService productService)
        {
            this.orderService = orderService;
            this.productService = productService;
        }

        [HttpGet(Url = "/")]
        public IActionResult IndexSlash()
        {
            return this.Index();
        }

        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                return this.IndexLoggedIn();
            }

            return this.View();
        }

        [NonAction]
        public IActionResult IndexLoggedIn()
        {
            Order currentActiveOrder = this.orderService.GetActiveOrder(this.User.Id);

            var viewModel = new OrderIndexViewModel();

            foreach (var orderProduct in currentActiveOrder.Products)
            {
                viewModel.Products.Add(new ProductIndexViewModel
                {
                    Name = orderProduct.Product.Name,
                    Price = $"${orderProduct.Product.Price:F2}"
                });
            }

            viewModel.TotalPrice = $"{currentActiveOrder.Products.Sum(p => p.Product.Price)}";

            return this.View(viewModel);
        }
    }
}

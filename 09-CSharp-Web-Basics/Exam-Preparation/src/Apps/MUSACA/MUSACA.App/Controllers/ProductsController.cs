namespace MUSACA.App.Controllers
{
    using MUSACA.App.BindingModels.Products;
    using MUSACA.App.VeiwModels.Products;
    using MUSACA.Models;
    using MUSACA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;

    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        private readonly IOrderService orderService;

        public ProductsController(IProductService productService, IOrderService orderService)
        {
            this.productService = productService;
            this.orderService = orderService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(ProductCreateInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Products/Create");
            }

            Product product = new Product
            {
                Name = model.Name,
                Price = model.Price
            };

            this.productService.Create(product);

            return this.Redirect("/Products/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var allProductsFromDb = this.productService.GetAll();

            var viewModel = new ProductsAllViewModel();

            foreach (var productFromDb in allProductsFromDb)
            {
                viewModel.Products.Add(new ProductAllViewModel
                {
                    Name = productFromDb.Name,
                    Price = $"${productFromDb.Price:F2}"
                });
            }

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Order(ProductOrderInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/");
            }

            Product orderedProduct = this.productService.GetProductByName(model.Product);

            this.orderService.AddProduct(this.User.Id, orderedProduct.Id);

            return this.Redirect("/");
        }
    }
}

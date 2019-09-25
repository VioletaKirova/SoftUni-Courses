namespace MUSACA.App.Controllers
{
    using MUSACA.App.BindingModels.Users;
    using MUSACA.App.VeiwModels.Orders;
    using MUSACA.Models;
    using MUSACA.Services;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes;
    using SIS.MvcFramework.Attributes.Action;
    using SIS.MvcFramework.Attributes.Security;
    using SIS.MvcFramework.Result;
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersController : Controller
    {
        private readonly IUserService userService;

        private readonly IOrderService orderService;

        public UsersController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            this.orderService = orderService;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Login");
            }

            User user = this.userService.GetUserByUsernameAndPassword(model.Username, this.HashPassword(model.Password));

            if (user == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(user.Id, user.Username, user.Email);

            return this.Redirect("/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect("/Users/Register");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            User user = new User
            {
                Username = model.Username,
                Password = this.HashPassword(model.Password),
                Email = model.Email
            };

            this.userService.Create(user);

            Order order = new Order
            {
                IssuedOn = DateTime.UtcNow,
                CashierId = user.Id
            };

            this.orderService.Create(order);


            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var completedOrders = this.orderService.GetCurrentUserCompletedOrders(this.User.Id);

            var viewModel = new OrdersAllProfileViewModel();

            foreach (var order in completedOrders)
            {
                viewModel.Orders.Add(new OrderAllProfileViewModel
                {
                    Id = order.Id,
                    Total = $"${order.Products.Sum(orderProduct => orderProduct.Product.Price):F2}",
                    IssuedOn = order.IssuedOn?.ToString("dd/MM/yyyy"),
                    Cashier = order.Cashier.Username
                });
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Logout()
        {
            this.SignOut();

            return this.Redirect("/");
        }

        [NonAction]
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return Encoding.UTF8.GetString(sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }
    }
}

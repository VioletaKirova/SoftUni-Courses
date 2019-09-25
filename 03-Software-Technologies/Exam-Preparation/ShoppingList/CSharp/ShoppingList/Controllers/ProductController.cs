namespace ShoppingList.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class ProductController : Controller
    {
        private readonly ShoppingListDbContext dbContext;

        public ProductController(ShoppingListDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var products = this.dbContext.Products.ToList();

            return View(products);
        }

        [HttpGet]
        [Route("/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Create(Product product)
        {
            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/edit/{id}")]
        public IActionResult Edit(int? id)
        {
            Product product = this.dbContext.Products.Find(id);

            return View(product);
        }

        [HttpPost]
        [Route("/edit/{id}")]
        public IActionResult Edit(Product product)
        {
            this.dbContext.Products.Update(product);
            this.dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

namespace MUSACA.Services
{
    using MUSACA.Data;
    using MUSACA.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductService : IProductService
    {
        private readonly MusacaDbContext dbContext;

        public ProductService(MusacaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Product Create(Product product)
        {
            var productFromDb = this.dbContext.Products.Add(product).Entity;
            this.dbContext.SaveChanges();

            return productFromDb;
        }

        public Product GetProductByName(string name)
        {
            var productFromDb = this.dbContext.Products
                .SingleOrDefault(product => product.Name == name);

            return productFromDb;
        }

        public ICollection<Product> GetAll()
        {
            return this.dbContext.Products.ToList();
        }       
    }
}

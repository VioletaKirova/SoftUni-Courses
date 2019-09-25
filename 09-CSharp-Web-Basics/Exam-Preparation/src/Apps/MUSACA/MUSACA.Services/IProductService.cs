namespace MUSACA.Services
{
    using MUSACA.Models;
    using System.Collections.Generic;

    public interface IProductService
    {
        Product Create(Product product);

        Product GetProductByName(string name);

        ICollection<Product> GetAll();
    }
}

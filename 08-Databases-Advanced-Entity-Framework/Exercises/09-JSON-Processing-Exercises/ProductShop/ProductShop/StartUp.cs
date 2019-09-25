namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using Dto.Export;
    using Models;

    public class StartUp
    {
        private const string ImportMessage = "Successfully imported {0}";

        public static void Main(string[] args)
        {
            //Needed for Problem 06. Export Sold Products
            Mapper.Initialize(am => am.AddProfile(new ProductShopProfile()));

            var context = new ProductShopContext();

            //Needed for Problems 01-04
            //var inputJson = File.ReadAllText(@"E:\SoftUni\CSharp-DB-Fund\DB-Advanced\09-JSON-Processing-Exercises\ProductShop\ProductShop\Datasets\categories-products.json");

            Console.WriteLine(GetUsersWithProducts(context));
        }

        // 08. Export Users and Products 

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new
                    {
                        Count = u.ProductsSold.Count(ps => ps.Buyer != null),
                        Products = u.ProductsSold
                            .Where(ps => ps.Buyer != null)
                            .Select(p => new
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .ToList()
                    }
                })
                .ToList();

            var result = new
            {
                UsersCount = users.Count,
                Users = users
            };

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var outputJson = JsonConvert.SerializeObject(result, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return outputJson;
        }

        // 07. Export Categories By Products Count 

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = $"{ c.CategoryProducts.Average(cp => cp.Product.Price):f2}",
                    TotalRevenue = $"{c.CategoryProducts.Sum(cp => cp.Product.Price):f2}"
                })
                .ToList();

            DefaultContractResolver contractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };


            var outputJson = JsonConvert.SerializeObject(categories, new JsonSerializerSettings()
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return outputJson;
        }

        // 06. Export Sold Products -> Using Dtos and AutoMapper

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users  
                .Include(p => p.ProductsSold)
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            foreach (var user in users)
            {
                var productsWithBuyers = user.ProductsSold
                    .Where(x => x.BuyerId != null)
                    .ToList();

                user.ProductsSold = productsWithBuyers;
            }

            var sellerDtos = Mapper.Map<List<SellerDto>>(users);

            var outputJson = JsonConvert.SerializeObject(sellerDtos, Formatting.Indented);

            return outputJson;
        }

        // 05. Export Products In Range

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new ProductDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .ToList();

            var outputJson = JsonConvert.SerializeObject(productDtos, Formatting.Indented);

            return outputJson;
        }

        // 04. Import Categories and Products 

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson)
                .ToList();

            context.CategoryProducts.AddRange(categoryProducts);
            var count = context.SaveChanges();

            return string.Format(ImportMessage, count);
        }

        // 03. Import Categories

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson)
                .Where(c => !string.IsNullOrEmpty(c.Name) && 
                            c.Name.Length >= 3 && 
                            c.Name.Length <= 15)
                .ToList();

            context.Categories.AddRange(categories);
            var importedCategoriesCount = context.SaveChanges();

            return string.Format(ImportMessage, importedCategoriesCount);
        }

        // 02. Import Products

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson)
                .Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Length > 2)
                .ToList();

            context.Products.AddRange(products);
            int importedProductsCount = context.SaveChanges();

            return string.Format(ImportMessage, importedProductsCount);
        }

        // 01. Import Users 

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<List<User>>(inputJson)
                .Where(u => !string.IsNullOrEmpty(u.LastName) && u.LastName.Length > 2)
                .ToList();

            context.Users.AddRange(users);
            int importedUsersCount = context.SaveChanges();

            return string.Format(ImportMessage, importedUsersCount);
        }
    }
}
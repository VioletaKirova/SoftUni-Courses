namespace ProductShop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    using AutoMapper;

    using Data;
    using Dtos.Export;
    using Dtos.Import;
    using Models;

    public class StartUp
    {
        private const string ImportMessage = "Successfully imported {0}";

        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.AddProfile<ProductShopProfile>());

            using (ProductShopContext context = new ProductShopContext())
            {
                //Needed for Problems 01-04
                //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");

                Console.WriteLine(GetUsersWithProducts(context));
            }
        }

        // 08. Export Users and Products

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userDtos = new ExportUsersWithCountDto()
            {
                Count = context.Users
                    .Count(x => x.ProductsSold.Any()),
                Users = context.Users
                    .Where(x => x.ProductsSold.Any())
                    .Select(x => new ExportUserProductsDto()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        SoldProducts = new ExportSoldProductsByCountDto()
                        {
                            Count = x.ProductsSold.Count,
                            Products = x.ProductsSold.Select(p => new ExportSoldProductDto()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                        }
                    })
                    .OrderByDescending(x => x.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportUsersWithCountDto), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), userDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 07. Export Categories By Products Count

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoryDtos = context.Categories
                .Select(c => new ExportCategoriesByProductsCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), categoryDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 06. Export Sold Products 

        public static string GetSoldProducts(ProductShopContext context)
        {
            var userDtos = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new ExortUserWithSoldProductDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.BuyerId != null)
                        .Select(ps => new ExportSoldProductDto()
                        {
                            Name = ps.Name,
                            Price = ps.Price
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExortUserWithSoldProductDto[]), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), userDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 05. Export Products In Range 

        public static string GetProductsInRange(ProductShopContext context)
        {
            var productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ExportProductInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName ?? p.Buyer.LastName
                })
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductInRangeDto[]), new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), productDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 04. Import Categories and Products 

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryIds = context.Categories.Select(x => x.Id).ToList();
            var productIds = context.Products.Select(x => x.Id).ToList();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));

            var importCategoryProductDtos = (ImportCategoryProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in importCategoryProductDtos)
            {
                var isValid = categoryIds.Contains(categoryProductDto.CategoryId) &&
                    productIds.Contains(categoryProductDto.ProductId);

                if (isValid)
                {
                    categoryProducts.Add(new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    });
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return string.Format(ImportMessage, categoryProducts.Count);
        }

        // 03. Import Categories 

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));

            var importCategoryDtos = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();

            foreach (var categoryDto in importCategoryDtos)
            {
                if (categoryDto.Name != null)
                {
                    categories.Add(new Category()
                    {
                        Name = categoryDto.Name
                    });
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return string.Format(ImportMessage, categories.Count);
        }

        // 02. Import Products 

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));

            var importProductDtos = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();

            foreach (var productDto in importProductDtos)
            {
                var product = Mapper.Map<Product>(productDto);

                if (product.Name != null)
                {
                    products.Add(product);
                }
            }

            context.Products.AddRange(products);
            context.SaveChanges();

            return string.Format(ImportMessage, products.Count);
        }

        // 01. Import Users 

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));

            var importUserDtos = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var users = new List<User>();

            foreach (var userDto in importUserDtos)
            {
                var user = Mapper.Map<User>(userDto);

                if (user.LastName != null)
                {
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();

            return string.Format(ImportMessage, users.Count);
        }
    }
}
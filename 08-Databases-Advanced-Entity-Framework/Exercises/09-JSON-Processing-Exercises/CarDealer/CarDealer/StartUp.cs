namespace CarDealer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using AutoMapper;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    using Data;
    using DTO.Export;
    using DTO.Import;
    using Models;

    public class StartUp
    {
        private const string ImportMessage = "Successfully imported {0}.";

        public static void Main(string[] args)
        {
            var context = new CarDealerContext();

            //Needed for Problems 09-13
            //var inputJson = File.ReadAllText(@"E:\SoftUni\CSharp-DB-Fund\DB-Advanced\09-JSON-Processing-Exercises\CarDealer\CarDealer\Datasets\sales.json");

            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        // 19. Export Sales With Applied Discount  

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var saleDtos = context.Sales
                .Take(10)
                .Select(s => new SaleExportDto()
                {
                    Car = new CarExportDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = $"{s.Discount:f2}",
                    Price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):f2}",
                    PriceWithDiscount = $"{(s.Car.PartCars.Sum(pc => pc.Part.Price) - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100)):f2}"
                })
                .ToList();

            var outputJson = JsonConvert.SerializeObject(saleDtos, Formatting.Indented);

            return outputJson;
        }

        // 18. Export Total Sales By Customer

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerDtos = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new CustomerDto()
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ThenByDescending(x => x.BoughtCars)
                .ToList();

            var outputJson = JsonConvert.SerializeObject(customerDtos, Formatting.Indented);

            return outputJson;
        }

        // 17. Export Cars With Their List Of Parts

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                        .Select(pc => new
                        {
                            Name = pc.Part.Name,
                            Price = $"{pc.Part.Price:f2}"
                        })
                        .ToList()
                })
                .ToList();

            var outputJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return outputJson;
        }

        // 16. Export Local Suppliers

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();

            var outputJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return outputJson;
        }

        // 15. Export Cars From Make Toyota 

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToList();

            var outputJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return outputJson;
        }

        // 14. Export Ordered Customers

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToList();

            var outputJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return outputJson;
        }

        // 13. Import Sales 

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            var importedSalesCount = context.SaveChanges();

            return string.Format(ImportMessage, importedSalesCount);
        }

        // 12. Import Customers 

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

            context.Customers.AddRange(customers);
            var importedCustomersCount = context.SaveChanges();

            return string.Format(ImportMessage, importedCustomersCount);
        }

        // 11. Import Cars 

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carDtos = JsonConvert.DeserializeObject<List<CarImportDto>>(inputJson);

            var cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        PartId = partId,
                        Car = car
                    });
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return string.Format(ImportMessage, cars.Count());
        }

        // 10. Import Parts 

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToHashSet();

            var parts = JsonConvert.DeserializeObject<List<Part>>(inputJson)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            var importedPartsCount = context.SaveChanges();

            return string.Format(ImportMessage, importedPartsCount);
        }

        // 09. Import Suppliers 

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

            context.Suppliers.AddRange(suppliers);
            var importedSuppliersCount = context.SaveChanges();

            return string.Format(ImportMessage, importedSuppliersCount);
        }
    }
}
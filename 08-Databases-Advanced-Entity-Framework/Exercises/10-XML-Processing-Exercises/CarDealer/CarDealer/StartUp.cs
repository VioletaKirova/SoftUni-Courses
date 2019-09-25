namespace CarDealer
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
            Mapper.Initialize(x => x.AddProfile<CarDealerProfile>());

            using (CarDealerContext context = new CarDealerContext())
            {
                //Needed for Problems 09-13
                //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");

                Console.WriteLine(GetSalesWithAppliedDiscount(context));
            }
        }

        // 19. Export Sales With Applied Discount 

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var saleDtos = context.Sales
                .Select(x => new ExportSaleWithDiscountDto()
                {
                    Car = new ExportCarForSaleDto()
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(y => y.Part.Price),
                    PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * (x.Discount / 100))).ToString().TrimEnd('0')
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportSaleWithDiscountDto[]), new XmlRootAttribute("sales"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), saleDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 18. Export Total Sales By Customer 

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customerDtos = context.Customers
                .Where(c => c.Sales.Any())
                .Select(x => new ExportCustomerSpentMoneyDto()
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomerSpentMoneyDto[]), new XmlRootAttribute("customers"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), customerDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 17. Export Cars With Their List Of Parts

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carDtos = context.Cars
                .Select(x => new ExportCarWithPartsDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(pc => new ExportPartDto()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithPartsDto[]), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), carDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 16. Export Local Suppliers

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var supplierDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(x => new ExportLocalSupplierDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSupplierDto[]), new XmlRootAttribute("suppliers"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), supplierDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 15. Export Cars From Make BMW

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carDtos = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(x => new ExportBMWCarDto()
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBMWCarDto[]), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), carDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 14. Export Cars With Distance

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carDtos = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(x => new ExportCarWithDistanceDto()
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarWithDistanceDto[]), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[]
            {
                new XmlQualifiedName("","")
            });

            xmlSerializer.Serialize(new StringWriter(sb), carDtos, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 13. Import Sales

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), new XmlRootAttribute("Sales"));

            var saleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();
            var validCarIds = context.Cars.Select(x => x.Id).ToList();

            foreach (var saleDto in saleDtos)
            {
                if (!validCarIds.Contains(saleDto.CarId))
                {
                    continue;
                }

                sales.Add(new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                });
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return string.Format(ImportMessage, sales.Count);
        }

        // 12. Import Customers

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustomerDto[]), new XmlRootAttribute("Customers"));

            var customerDtos = (ImportCustomerDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                var customer = Mapper.Map<Customer>(customerDto);

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return string.Format(ImportMessage, customers.Count);
        }

        // 11. Import Cars 

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), new XmlRootAttribute("Cars"));

            var carDtos = (ImportCarDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();

            var validPartIds = context.Parts.Select(x => x.Id).ToList();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var uniquePartIds = carDto.PartCars.Select(x => x.Id).Distinct();
                var partCars = new List<PartCar>();

                foreach (var partId in uniquePartIds)
                {
                    if (!validPartIds.Contains(partId))
                    {
                        continue;
                    }

                    partCars.Add(new PartCar
                    {
                        PartId = partId,
                        Car = car
                    });
                }

                car.PartCars = partCars;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return string.Format(ImportMessage, cars.Count);
        }

        // 10. Import Parts

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPartDto[]), new XmlRootAttribute("Parts"));

            var partDtos = (ImportPartDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();
            var validSupplierIds = context.Suppliers.Select(x => x.Id).ToList();

            foreach (var partDto in partDtos)
            {
                if (!validSupplierIds.Contains(partDto.SupplierId))
                {
                    continue;
                }

                var part = new Part()
                {
                    Name = partDto.Name,
                    Price = partDto.Price,
                    Quantity = partDto.Quantity,
                    SupplierId = partDto.SupplierId
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return string.Format(ImportMessage, parts.Count);
        }

        // 09. Import Suppliers

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), new XmlRootAttribute("Suppliers"));

            var supplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();

            foreach (var supplierDto in supplierDtos)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return string.Format(ImportMessage, suppliers.Count);
        }
    }
}
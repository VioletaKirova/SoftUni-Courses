using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_SalesReport
{
    class Program
    {
        class Sale
        {
            public string Town { get; set; }
            public string Product { get; set; }
            public decimal Price { get; set; }
            public decimal Quantity { get; set; }
        }

        static Sale[] ReadSales()
        {
            int n = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[n];

            for (int i = 0; i < n; i++)
            {
                sales[i] = ReadSale();
            }

            return sales;
        }

        static Sale ReadSale()
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            Sale sale = new Sale();
            sale.Town = input[0];
            sale.Product = input[1];
            sale.Price = decimal.Parse(input[2]);
            sale.Quantity = decimal.Parse(input[3]);
            return sale;
        }

        static SortedDictionary<string, decimal> CalcSalesByTown(Sale[] sales)
        {
            var salesByTown = new SortedDictionary<string, decimal>();

            foreach (var sale in sales)
            {
                if (!salesByTown.ContainsKey(sale.Town))
                    salesByTown[sale.Town] = sale.Price * sale.Quantity;
                else
                    salesByTown[sale.Town] += sale.Price * sale.Quantity;
            }

            return salesByTown;
        }

        static void PrintSalesByTown(SortedDictionary<string, decimal> salesByTown)
        {
            foreach (var s in salesByTown)
            {
                Console.WriteLine($"{s.Key} -> {s.Value:f2}");
            }
        }

        static void Main(string[] args)
        {
            Sale[] sales = ReadSales();
            SortedDictionary<string, decimal> salesByTown = CalcSalesByTown(sales);
            PrintSalesByTown(salesByTown);
        }
    }
}
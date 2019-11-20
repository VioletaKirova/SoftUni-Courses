using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_SupermarketDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var database = new Dictionary<string, Dictionary<double, double>>();

            string input = Console.ReadLine();

            while (input != "stocked")
            {
                List<string> inputLine = input.Split(' ').ToList();

                string product = inputLine[0];
                double price = double.Parse(inputLine[1]);
                double quantity = double.Parse(inputLine[2]);

                if (!database.ContainsKey(product))
                    database.Add(product, new Dictionary<double, double>());

                if (!database[product].ContainsKey(price))
                    database[product][price] = 0.0;

                database[product][price] += quantity;

                input = Console.ReadLine();
            }

            double grandTotal = 0.0;

            foreach (var p in database)
            {
                string name = p.Key;
                double price = p.Value.Keys.Last();
                double quantity = p.Value.Values.Sum();
                double total = price * quantity;
                grandTotal += total;

                Console.WriteLine($"{name}: ${price:f2} * {quantity} = ${total:f2}");
            }

            Console.WriteLine(new string('-', 30));

            Console.WriteLine($"Grand Total: ${grandTotal:f2}");
        }
    }
}
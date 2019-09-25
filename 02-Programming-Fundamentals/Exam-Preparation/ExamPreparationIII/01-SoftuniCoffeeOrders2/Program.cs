using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace _01_SoftuniCoffeeOrders
{
    class Program
    { 
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            decimal price = 0.0m;
            decimal totalPrice = 0.0m;

            for (int i = 0; i < countOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                decimal capsules = decimal.Parse(Console.ReadLine());
                int days = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                price = ((decimal)days * capsules) * pricePerCapsule;
                totalPrice += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
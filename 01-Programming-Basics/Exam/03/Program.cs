using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            double weight = double.Parse(Console.ReadLine());
            string type = Console.ReadLine().ToLower();
            double distance = double.Parse(Console.ReadLine());

            double price = 0.0;
            double extra = 0.0;
            double extraPrice = 0.0;

            if (type == "standard")
            {
                if (weight < 1)
                {
                    price = distance * 0.03;
                }
                else if (weight >= 1 && weight <= 10)
                {
                    price = distance * 0.05;
                }
                else if (weight >= 11 && weight <= 40)
                {
                    price = distance * 0.1;
                }
                else if (weight >= 41 && weight <= 90)
                {
                    price = distance * 0.15;
                }
                else if (weight >= 91 && weight <= 150)
                {
                    price = distance * 0.2;
                }
            }
            else if (type == "express")
            {
                if (weight < 1)
                {
                    price = distance * 0.03;
                    extra = 0.03 * 0.8;
                }
                else if (weight >= 1 && weight <= 10)
                {
                    price = distance * 0.05;
                    extra = 0.05 * 0.4;
                }
                else if (weight >= 11 && weight <= 40)
                {
                    price = distance * 0.1;
                    extra = 0.1 * 0.05;
                }
                else if (weight >= 41 && weight <= 90)
                {
                    price = distance * 0.15;
                    extra = 0.15 * 0.02;
                }
                else if (weight >= 91 && weight <= 150)
                {
                    price = distance * 0.2;
                    extra = 0.2 * 0.01;
                    
                }

                extraPrice = (weight * extra) * distance;
                price += extraPrice; 
            }

            Console.WriteLine($"The delivery of your shipment with weight of {weight:f3} kg. would cost {price:f2} lv.");
        }
    }
}

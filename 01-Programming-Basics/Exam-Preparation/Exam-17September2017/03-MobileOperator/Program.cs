using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MobileOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string years = Console.ReadLine();
            string type = Console.ReadLine();
            string addedInternet = Console.ReadLine();
            double months = double.Parse(Console.ReadLine());
            double price = 0;
            double priceForAllMonths = 0;

            if (type == "Small")
            {
                if (years == "one")
                {
                    price = 9.98;
                }
                else if (years == "two")
                {
                    price = 8.58;
                }              
            }
            else if (type == "Middle")
            {
                if (years == "one")
                {
                    price = 18.99;
                }
                else if (years == "two")
                {
                    price = 17.09;
                }
            }
            else if (type == "Large")
            {
                if (years == "one")
                {
                    price = 25.98;
                }
                else if (years == "two")
                {
                    price = 23.59;
                }
            }
            else if (type == "ExtraLarge")
            {
                if (years == "one")
                {
                    price = 35.99;
                }
                else if (years == "two")
                {
                    price = 31.79;
                }
            }

            if (addedInternet == "yes")
            {
                if (price <= 10)
                {
                    price +=  5.50;
                }
                else if (price <= 30)
                {
                    price += 4.35;
                }
                else if (price > 30)
                {
                    price += 3.85;
                }
            }

            priceForAllMonths = months * price;

            if (years == "two")
            {
                priceForAllMonths -= priceForAllMonths * 0.0375;
            }

            Console.WriteLine($"{priceForAllMonths:f2} lv.");
        }
    }
}

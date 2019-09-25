using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_RestaurantDiscount
{
    class Program
    {
        static void Main(string[] args)
        {
            var groupSize = int.Parse(Console.ReadLine());
            var package = Console.ReadLine();
            var hall = " ";
            var hallPrice = 0.0;
            var fullPrice = 0.0;

            if (groupSize <= 50)
            {
                hall = "Small Hall";
                hallPrice = 2500;
            }
            else if (groupSize > 50 && groupSize <= 100)
            {
                hall = "Terrace";
                hallPrice = 5000;
            }
            else if (groupSize > 100 && groupSize <= 120)
            {
                hall = "Great Hall";
                hallPrice = 7500;
            }

            switch (package)
            {
                case "Normal":
                    fullPrice = hallPrice + 500;
                    fullPrice -= fullPrice * 0.05;
                    break;
                case "Gold":
                    fullPrice = hallPrice + 750;
                    fullPrice -= fullPrice * 0.1;
                    break;
                case "Platinum":
                    fullPrice = hallPrice + 1000;
                    fullPrice -= fullPrice * 0.15;
                    break;
            }

            var pricePerPerson = fullPrice / groupSize;

            if (hall == " ")
            {
                Console.WriteLine("We do not have an appropriate hall.");
            }
            else
            {
                Console.WriteLine($"We can offer you the {hall}");
                Console.WriteLine($"The price per person is {pricePerPerson:f2}$");
            }
        }
    }
}

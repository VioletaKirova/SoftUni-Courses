using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            var month = Console.ReadLine();
            var nights = int.Parse(Console.ReadLine());

            var studioPrice = 0.0;
            var doublePrice = 0.0;
            var suitePrice = 0.0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50;
                doublePrice = 65;
                suitePrice = 75;
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 60;
                doublePrice = 72;
                suitePrice = 82;
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPrice = 68;
                doublePrice = 77;
                suitePrice = 89;
            }

            if ((month == "May" || month == "October") && nights > 7)
            {
                studioPrice *= 0.95;
            }
            else if ((month == "June" || month == "September") && nights > 14)
            {
                doublePrice *= 0.9;
            }
            else if ((month == "July" || month == "August" || month == "December") && nights > 14)
            {
                suitePrice *= 0.85;
            }

            var finalStudioPrice = studioPrice * nights;
            var finalDoublePrice = doublePrice * nights;
            var finalSuitePrice = suitePrice * nights;

            if ((month == "September" || month == "October") && nights > 7)
            {
                finalStudioPrice -= studioPrice;
            }

            Console.WriteLine($"Studio: {finalStudioPrice:f2} lv.");
            Console.WriteLine($"Double: {finalDoublePrice:f2} lv.");
            Console.WriteLine($"Suite: {finalSuitePrice:f2} lv.");
        }
    }
}

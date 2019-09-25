using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DogHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double sidesArea = (a * (a / 2)) * 2;
            double backArea = ((a / 2) * (a / 2)) + (((a / 2) * (b - a / 2)) / 2);
            double frontArea = backArea - ((a / 5) * (a / 5));

            double allSidesArea = sidesArea + backArea + frontArea;

            double roofArea = (a * (a / 2)) * 2;

            double litersGreenPaint = allSidesArea / 3;
            double litersRedPaint = roofArea / 5;

            Console.WriteLine($"{litersGreenPaint:f2}");
            Console.WriteLine($"{litersRedPaint:f2}");
        }
    }
}

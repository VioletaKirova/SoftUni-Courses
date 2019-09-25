using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double sidesArea = (x * y - 1.5 * 1.5) * 2;
            double frontAndBackArea = (x * x - 1.2 * 2)  + x * x;

            double sideRoofArea = (x * y) * 2;
            double frontAndBackRoofArea = ((x * h) / 2) * 2;

            double areaWithGreenPaint = sidesArea + frontAndBackArea;
            double areaWithRedPaint = sideRoofArea + frontAndBackRoofArea;

            double litersGreenPaint = areaWithGreenPaint / 3.4;
            double litersRedPaint = areaWithRedPaint / 4.3;

            Console.WriteLine($"{litersGreenPaint:f2}");
            Console.WriteLine($"{litersRedPaint:f2}");
        }
    }
}

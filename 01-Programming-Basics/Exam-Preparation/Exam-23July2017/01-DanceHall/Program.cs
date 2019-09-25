using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());

            double areaOfHall = (l * 100) * (w * 100);
            double areaOfBench = areaOfHall / 10;
            double areaOfWardrobe = Math.Pow(a * 100, 2);
            double freeArea = areaOfHall - (areaOfBench + areaOfWardrobe);

            double dancers = Math.Floor(freeArea / 7040);

            Console.WriteLine(dancers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CubeProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            string parameter = Console.ReadLine();

            switch (parameter)
            {
                case "face":
                    Console.WriteLine($"{FindFaceDiagonal(a):f2}");
                    break;
                case "space":
                    Console.WriteLine($"{FindSpaceDiagonal(a):f2}");
                    break;
                case "volume":
                    Console.WriteLine($"{FindVolume(a):f2}");
                    break;
                case "area":
                    Console.WriteLine($"{FindSurfaceArea(a):f2}");
                    break;
            }
        }

        static double FindFaceDiagonal(double a)
        {
            double faceDiagonal = Math.Sqrt(2 * (a * a));
            return faceDiagonal;
        }

        static double FindSpaceDiagonal(double a)
        {
            double spaceDiagonal = Math.Sqrt(3 * (a * a));
            return spaceDiagonal;
        }

        static double FindVolume(double a)
        {
            double volume = Math.Pow(a, 3);
            return volume;
        }

        static double FindSurfaceArea(double a)
        {
            double area = 6 * Math.Pow(a, 2);
            return area;
        }
    }
}

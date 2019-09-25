using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double percentFull = double.Parse(Console.ReadLine());

            double v = length * width * height;
            double liters = v * 0.001;
            double percent = percentFull * 0.01;
            double neededLiters = liters * (1 - percent);

            Console.WriteLine($"{neededLiters:f3}");
        }
    }
}

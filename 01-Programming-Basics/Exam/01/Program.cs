using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double pricePerMeter = double.Parse(Console.ReadLine());
            double weightPerSqrtMeter = double.Parse(Console.ReadLine());

            double fullLength = 2 * length + 2 * width;
            double cost = fullLength * pricePerMeter;
            double area = fullLength * height;
            double weight = area * weightPerSqrtMeter;

            Console.WriteLine(fullLength);
            Console.WriteLine($"{cost:f2}");
            Console.WriteLine($"{weight:f3}");
        }
    }
}

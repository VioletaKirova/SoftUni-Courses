using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double inputSum = 0;
            double outputSum = 0;

            if (input == "m") inputSum = sum;
            else if (input == "mm") inputSum = sum / 1000;
            else if (input == "cm") inputSum = sum / 100;
            else if (input == "mi") inputSum = sum / 0.000621371192;
            else if (input == "in") inputSum = sum / 39.3700787;
            else if (input == "km") inputSum = sum / 0.001;
            else if (input == "ft") inputSum = sum / 3.2808399;
            else if (input == "yd") inputSum = sum / 1.0936133;

            if (output == "m") outputSum = inputSum;
            else if (output == "mm") outputSum = inputSum * 1000;
            else if (output == "cm") outputSum = inputSum * 100;
            else if (output == "mi") outputSum = inputSum * 0.000621371192;
            else if (output == "in") outputSum = inputSum * 39.3700787;
            else if (output == "km") outputSum = inputSum * 0.001;
            else if (output == "ft") outputSum = inputSum * 3.2808399;
            else if (output == "yd") outputSum = inputSum * 1.0936133;

            Console.WriteLine($"{outputSum:f8}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_TemperatureConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = FahrenheitToCelsius(fahrenheit);
            Console.WriteLine($"{celsius:f2}");
        }

        static double FahrenheitToCelsius(double input)
        {
            return (input - 32) * 5 / 9;
        }
    }
}

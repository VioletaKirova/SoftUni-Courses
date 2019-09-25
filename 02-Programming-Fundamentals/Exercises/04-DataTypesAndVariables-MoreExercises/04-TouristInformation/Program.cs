using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_TouristInformation
{
    class Program
    {
        static void Main(string[] args)
        {
            string imperialUnit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            double outputValue = 0.0;
            string outputUnit = "";

            switch (imperialUnit)
            {
                case "miles":
                    outputValue = value * 1.6;
                    outputUnit = "kilometers";
                    break;
                case "inches":
                    outputValue = value * 2.54;
                    outputUnit = "centimeters";
                    break;
                case "feet":
                    outputValue = value * 30;
                    outputUnit = "centimeters";
                    break;
                case "yards":
                    outputValue = value * 0.91;
                    outputUnit = "meters";
                    break;
                case "gallons":
                    outputValue = value * 3.8;
                    outputUnit = "liters";
                    break;
            }

            Console.WriteLine($"{value} {imperialUnit} = {outputValue:f2} {outputUnit}");
        }
    }
}

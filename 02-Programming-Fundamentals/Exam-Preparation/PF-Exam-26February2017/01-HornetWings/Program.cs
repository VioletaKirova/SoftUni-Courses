using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            decimal thousandFlapsDistance = decimal.Parse(Console.ReadLine());
            int endurance = int.Parse(Console.ReadLine());

            decimal distance = ((decimal)wingFlaps / 1000) * thousandFlapsDistance;
            int seconds = (wingFlaps / 100) + ((wingFlaps / endurance) * 5);

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{seconds:f0} s.");
        }
    }
}
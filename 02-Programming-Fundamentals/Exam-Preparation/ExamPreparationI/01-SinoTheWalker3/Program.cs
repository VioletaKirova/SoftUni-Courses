using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace _01_SinoTheWalker3
{
    // 80/100
    class Program
    {   
        static void Main(string[] args)
        {
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            int steps = int.Parse(Console.ReadLine());
            int secsForEachStep = int.Parse(Console.ReadLine());

            BigInteger neededSeconds = steps * secsForEachStep;

            time = time.AddSeconds((double)neededSeconds);

            Console.WriteLine("Time Arrival: " + time.ToString("HH:mm:ss"));
        }
    }
}
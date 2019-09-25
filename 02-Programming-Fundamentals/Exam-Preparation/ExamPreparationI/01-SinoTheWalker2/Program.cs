using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace _01_SinoTheWalker2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            int steps = int.Parse(Console.ReadLine())% 86400;
            int secsPerStep = int.Parse(Console.ReadLine())% 86400;
            int secsToGetHome = steps * secsPerStep;
            time = time.AddSeconds(secsToGetHome);
            Console.WriteLine($"Time Arrival: {time.ToString("HH:mm:ss")}");
        }
    }
}
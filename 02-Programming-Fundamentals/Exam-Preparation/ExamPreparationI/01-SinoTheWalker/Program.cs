using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace _01_SinoTheWalker
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

            TimeSpan t = TimeSpan.FromSeconds((double)neededSeconds);

            DateTime neededTime = DateTime.ParseExact(string.Format("{0:D2}:{1:D2}:{2:D2}",
                            t.Hours,
                            t.Minutes,
                            t.Seconds), "HH:mm:ss", CultureInfo.InvariantCulture);

            time = time
                .AddHours(neededTime.Hour)
                .AddMinutes(neededTime.Minute)
                .AddSeconds(neededTime.Second);

            Console.WriteLine("Time Arrival: " + time.ToString("HH:mm:ss"));
        }
    }
}
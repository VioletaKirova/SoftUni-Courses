using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01_Snowballs
{
    class Program
    {
        class Snowball
        {
            public double Snow { get; set; }
            public double Time { get; set; }
            public int Quantity { get; set; }
            public BigInteger Value { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            BigInteger biggestValue = 0;
            List<Snowball> snowballs = new List<Snowball>();

            for (int i = 0; i < n; i++)
            {
                Snowball snowball = new Snowball();
                snowball.Snow = double.Parse(Console.ReadLine());
                snowball.Time = double.Parse(Console.ReadLine());
                snowball.Quantity = int.Parse(Console.ReadLine());
                snowball.Value = BigInteger.Pow((BigInteger)(snowball.Snow / snowball.Time), snowball.Quantity);

                if (snowball.Value >= biggestValue)
                {
                    biggestValue = snowball.Value;
                }

                snowballs.Add(snowball);
            }

            foreach (var s in snowballs)
            {
                if (s.Value == biggestValue)
                {
                    Console.WriteLine($"{s.Snow} : {s.Time} = {s.Value} ({s.Quantity})");
                    break;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());

            double biggestVol = 0.0;
            string biggestModel = "";

            for (sbyte i = 0; i < n; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * (radius * radius) * (double)height;

                if (volume > biggestVol)
                {
                    biggestVol = volume;
                    biggestModel = model;
                }
            }

            Console.WriteLine(biggestModel);
        }
    }
}

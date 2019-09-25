using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int litersInTank = 0;

            for (int i = 0; i < n; i++)
            {
                int liters = int.Parse(Console.ReadLine());

                if (litersInTank + liters > 255)
                    Console.WriteLine("Insufficient capacity!");
                else
                    litersInTank += liters;
            }

            Console.WriteLine(litersInTank);
        }
    }
}

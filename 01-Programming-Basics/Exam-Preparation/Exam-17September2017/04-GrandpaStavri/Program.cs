using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GrandpaStavri
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double allLitersRakia = 0;
            double degreeOfRakia = 0;

            for (int i = 1; i <= n; i++)
            {
                double litersRakiaPerDay = double.Parse(Console.ReadLine());
                allLitersRakia += litersRakiaPerDay;

                double degreesOfRakiaPerDay = double.Parse(Console.ReadLine());
                degreeOfRakia += litersRakiaPerDay * degreesOfRakiaPerDay;
            }

            degreeOfRakia = degreeOfRakia / allLitersRakia;

            Console.WriteLine($"Liter: {allLitersRakia:f2}");
            Console.WriteLine($"Degrees: {degreeOfRakia:f2}");

            if (degreeOfRakia < 38)
            {
                Console.WriteLine("Not good, you should baking!");
            }
            else if (degreeOfRakia >= 38 && degreeOfRakia <= 42)
            {
                Console.WriteLine("Super!");
            }
            else if (degreeOfRakia > 42)
            {
                Console.WriteLine("Dilution with distilled water!");
            }
        }
    }
}

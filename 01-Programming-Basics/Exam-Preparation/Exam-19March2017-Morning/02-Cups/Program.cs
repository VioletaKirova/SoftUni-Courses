using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Cups
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededCups = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());
            double workDays = double.Parse(Console.ReadLine());

            double workingHours = workers * workDays * 8;
            double cupsMade = Math.Floor(workingHours / 5);

            double winsOrLoses = Math.Abs(cupsMade - neededCups) * 4.2;

            if (cupsMade > neededCups)
            {
                Console.WriteLine($"{winsOrLoses:f2} extra money");
            }
            else
            {
                Console.WriteLine($"Losses: {winsOrLoses:f2}");
            }
        }
    }
}

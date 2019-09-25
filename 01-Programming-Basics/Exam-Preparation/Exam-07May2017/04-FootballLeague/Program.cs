using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_FootballLeague
{
    class Program
    {
        static void Main(string[] args)
        {
            double capacityOfStadium = double.Parse(Console.ReadLine());
            double numberOfFans = double.Parse(Console.ReadLine());

            int sectorA = 0;
            int sectorB = 0;
            int sectorV = 0;
            int sectorG = 0;

            for (int i = 1; i <= numberOfFans; i++)
            {
                string sector = Console.ReadLine().ToUpper();

                switch (sector)
                {
                    case "A": sectorA++; break;
                    case "B": sectorB++; break;
                    case "V": sectorV++; break;
                    case "G": sectorG++; break;
                }
            }

            double percentA = sectorA / numberOfFans * 100;
            double percentB = sectorB / numberOfFans * 100;
            double percentV = sectorV / numberOfFans * 100;
            double percentG = sectorG / numberOfFans * 100;
            double percentOfAllFans = numberOfFans / capacityOfStadium * 100;

            Console.WriteLine($"{percentA:f2}%");
            Console.WriteLine($"{percentB:f2}%");
            Console.WriteLine($"{percentV:f2}%");
            Console.WriteLine($"{percentG:f2}%");
            Console.WriteLine($"{percentOfAllFans:f2}%");
        }
    }
}

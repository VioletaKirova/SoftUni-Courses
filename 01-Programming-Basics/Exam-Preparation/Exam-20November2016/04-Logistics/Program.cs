using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int loads = int.Parse(Console.ReadLine());

            double tonsForMicrobus = 0.0;
            double tonsForTruck = 0.0;
            double tonsForTrain = 0.0;

            double allTons = 0.0;

            for (int i = 0; i < loads; i++)
            {
                double tons = double.Parse(Console.ReadLine());

                allTons += tons;

                if (tons <= 3)
                {
                    tonsForMicrobus += tons;
                }
                else if (tons > 3 && tons <= 11)
                {
                    tonsForTruck += tons;
                }
                else if (tons > 11)
                {
                    tonsForTrain += tons;
                }
            }

            double microbusCost = tonsForMicrobus * 200;
            double truckCost = tonsForTruck * 175;
            double trianCost = tonsForTrain * 120;

            double averageCostPerTon = (microbusCost + truckCost + trianCost) / allTons;

            double percentTonsInMicrobus = tonsForMicrobus / allTons * 100;
            double percentTonsInTruck = tonsForTruck / allTons * 100;
            double percentTonsInTrain = tonsForTrain / allTons * 100;

            Console.WriteLine($"{averageCostPerTon:f2}");
            Console.WriteLine($"{percentTonsInMicrobus:f2}%");
            Console.WriteLine($"{percentTonsInTruck:f2}%");
            Console.WriteLine($"{percentTonsInTrain:f2}%");
        }
    }
}

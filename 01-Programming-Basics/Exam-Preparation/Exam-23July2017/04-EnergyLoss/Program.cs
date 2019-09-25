using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_EnergyLoss
{
    class Program
    {
        static void Main(string[] args)
        {
            int trainingDays = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int maxEnergy = 100 * trainingDays * dancers;
            double energyPerDay = 0;
            double wastedEnergy = 0;

            for (int i = 1; i <= trainingDays; i++)
            {
                int trainingHours = int.Parse(Console.ReadLine());

                if (i % 2 == 0 && trainingHours % 2 == 0)
                {
                    energyPerDay = dancers * 68;
                }
                else if (i % 2 != 0 && trainingHours % 2 == 0)
                {
                    energyPerDay = dancers * 49;
                }
                else if (i % 2 == 0 && trainingHours % 2 != 0)
                {
                    energyPerDay = dancers * 65;
                }
                else if (i % 2 != 0 && trainingHours % 2 != 0)
                {
                    energyPerDay = dancers * 30;
                }

                wastedEnergy += energyPerDay;
            }

            double energyLeft = maxEnergy - wastedEnergy;
            double energyLeftPerDancer = energyLeft / dancers / trainingDays;

            if (energyLeftPerDancer >= 50)
            {
                Console.WriteLine($"They feel good! Energy left: {energyLeftPerDancer:f2}");
            }
            else
            {
                Console.WriteLine($"They are wasted! Energy left: {energyLeftPerDancer:f2}");
            }
        }
    }
}

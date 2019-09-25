using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_MoneyReward
{
    class Program
    {
        static void Main(string[] args)
        {
            int projectParts = int.Parse(Console.ReadLine());
            double moneyPerPoint = double.Parse(Console.ReadLine());
            double evenPoints = 0.0;
            double oddPoints = 0.0;
            double moneyReward = 0.0;

            for (int i = 1; i <= projectParts; i++)
            {
                int points = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    evenPoints += points * 2;
                }
                else
                {
                    oddPoints += points;
                }
            }

            moneyReward = (evenPoints + oddPoints) * moneyPerPoint;

            Console.WriteLine($"The project prize was {moneyReward:f2} lv.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BackToThePast
{
    class Program
    {
        static void Main(string[] args)
        {
            double inheritedMoney = double.Parse(Console.ReadLine());
            int finalYear = int.Parse(Console.ReadLine());

            double neededMoney = 0.0;
            double moneyLeftOrNeeded = 0.0;

            int years = finalYear - 1799;
            int yearsOld = 17;

            for (int i = 0; i < years; i++)
            {
                yearsOld++;

                if (i % 2 == 0)
                {
                    neededMoney += 12000;
                }
                else
                {
                    neededMoney += (12000 + 50 * yearsOld);
                }
            }

            moneyLeftOrNeeded = Math.Abs(neededMoney - inheritedMoney);

            if (neededMoney <= inheritedMoney)
            {          
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeftOrNeeded:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {moneyLeftOrNeeded:f2} dollars to survive.");
            }
        }
    }
}

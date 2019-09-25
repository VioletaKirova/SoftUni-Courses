using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FinalCompetiton
{
    class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string place = Console.ReadLine().ToLower();

            double sum = 0.0;

            if (place == "bulgaria")
            {
                sum = points * dancers;

                if (season == "summer")
                {
                    sum -= sum * 0.05;
                }
                else if (season == "winter")
                {
                    sum -= sum * 0.08;
                }
            }
            else if (place == "abroad")
            {
                sum = points * dancers;
                sum += sum * 0.5;

                if (season == "summer")
                {
                    sum -= sum * 0.1;
                }
                else if (season == "winter")
                {
                    sum -= sum * 0.15;
                }
            }

            double charity = sum * 0.75;
            double sumLeft = sum - charity;
            double moneyPerDancer = sumLeft / dancers;

            Console.WriteLine($"Charity - {charity:f2}");
            Console.WriteLine($"Money per dancer - {moneyPerDancer:f2}");
        }
    }
}

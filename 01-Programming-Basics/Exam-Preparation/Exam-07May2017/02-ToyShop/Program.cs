using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ToyShop
{
    class Program
    {
        static void Main(string[] args)
        {
            double vacationCost = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int stuffedBears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            int allToys = puzzles + dolls + stuffedBears + minions + trucks;

            double puzzlesCost = puzzles * 2.6;
            double dollsCost = dolls * 3;
            double stuffedBearsCost = stuffedBears * 4.1;
            double minionsCost = minions * 8.2;
            double trucksCost = trucks * 2;

            double fullCost = puzzlesCost + dollsCost + stuffedBearsCost + minionsCost + trucksCost;

            if (allToys >= 50)
            {
                fullCost -= fullCost * 0.25;
            }

            fullCost -= fullCost * 0.1;

            double extraOrNeededMoney = Math.Abs(fullCost - vacationCost);

            if (fullCost >= vacationCost)
            {
                Console.WriteLine($"Yes! {extraOrNeededMoney:f2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {extraOrNeededMoney:f2} lv needed.");
            }
        }
    }
}

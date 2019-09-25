using System;

namespace _01
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal money = decimal.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            decimal saberPrice = decimal.Parse(Console.ReadLine());
            decimal robePrice = decimal.Parse(Console.ReadLine());
            decimal beltPrice = decimal.Parse(Console.ReadLine());

            int freeBelts = studentsCount / 6;

            decimal equipmentPrice = (saberPrice * (studentsCount + Math.Ceiling(studentsCount * 0.1m))) + (robePrice * studentsCount) + (beltPrice * (studentsCount - freeBelts));

            if (equipmentPrice <= money)
            {
                Console.WriteLine($"The money is enough - it would cost {equipmentPrice:f2}lv.");
            }
            else
            {
                decimal neededMoney = equipmentPrice - money; 
                Console.WriteLine($"Ivan Cho will need {neededMoney:f2}lv more.");
            }
        }
    }
}
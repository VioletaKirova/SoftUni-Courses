using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_SweetDessert
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cashAmount = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal bananasPrice = decimal.Parse(Console.ReadLine());
            decimal eggsPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());
            int numbersOfPortions = 0;

            if (guests % 6 == 0)
                numbersOfPortions = guests / 6;
            else
                numbersOfPortions = guests / 6 + 1;

            decimal neededCash = (numbersOfPortions * (2 * bananasPrice)) + (numbersOfPortions * (4 * eggsPrice)) + (numbersOfPortions * ((decimal)0.2 * berriesPrice));

            if (neededCash <= cashAmount)
                Console.WriteLine($"Ivancho has enough money - it would cost {neededCash:f2}lv.");
            else
            {
                decimal needed = neededCash - cashAmount;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {needed:f2}lv more.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChangeTiles
{
    class Program
    {
        static void Main(string[] args)
        {
            double savedMoney = double.Parse(Console.ReadLine());
            double floorWidth = double.Parse(Console.ReadLine());
            double floorLength = double.Parse(Console.ReadLine());
            double sideOfTriangle = double.Parse(Console.ReadLine());
            double heightOfTriangle = double.Parse(Console.ReadLine());
            double priceOfOneTile = double.Parse(Console.ReadLine());
            double moneyForWorkman = double.Parse(Console.ReadLine());

            double areaOfFloor = floorWidth * floorLength;
            double areaOfOneTile = sideOfTriangle * heightOfTriangle / 2;

            double neededTiles = Math.Ceiling(areaOfFloor / areaOfOneTile) + 5;
            double priceOfAllTiles = neededTiles *priceOfOneTile;
            double fullPrice = priceOfAllTiles + moneyForWorkman;

            if (fullPrice <= savedMoney)
            {
                double extraMoney = savedMoney - fullPrice;
                Console.WriteLine($"{extraMoney:f2} lv left.");
            }
            else if (fullPrice > savedMoney)
            {
                double neededMoney = fullPrice - savedMoney;
                Console.WriteLine($"You'll need {neededMoney:f2} lv more.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_TailoringWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            double tables = double.Parse(Console.ReadLine());
            double tableHeight = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());

            double sideOfSquare = tableHeight * 0.5;
            double areaOfSquare = sideOfSquare * sideOfSquare;

            double heightOfRectangle = tableHeight + 0.6;
            double widthOfRectangle = tableWidth + 0.6;
            double areaOfRectangle = heightOfRectangle * widthOfRectangle;

            double quantityOfSquares = tables * areaOfSquare;
            double quantityOfRectangles = tables * areaOfRectangle;

            double priceOfSquaresInUSD = quantityOfSquares * 9;
            double priceOfRectanglesInUSD = quantityOfRectangles * 7;
            double priceInUSD = priceOfSquaresInUSD + priceOfRectanglesInUSD;

            double priceOfSquaresInBGN = priceOfSquaresInUSD * 1.85;
            double priceOfRectanglesInBGN = priceOfRectanglesInUSD * 1.85;
            double priceInBGN = priceOfSquaresInBGN + priceOfRectanglesInBGN;

            Console.WriteLine($"{priceInUSD:f2} USD");
            Console.WriteLine($"{priceInBGN:f2} BGN");
        }
    }
}

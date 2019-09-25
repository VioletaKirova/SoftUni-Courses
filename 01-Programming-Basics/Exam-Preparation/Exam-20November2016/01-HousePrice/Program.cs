using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HousePrice
{
    class Program
    {
        static void Main(string[] args)
        {
            double areaOfSmallestRoom = double.Parse(Console.ReadLine());
            double areaOfKitchen = double.Parse(Console.ReadLine());
            double priceOfSquareMeter = double.Parse(Console.ReadLine());

            double areaOfBathroom = areaOfSmallestRoom * 0.5;
            double areaOfSecondRoom = areaOfSmallestRoom + areaOfSmallestRoom * 0.1;
            double areaOfThirdRoom = areaOfSecondRoom + areaOfSecondRoom * 0.1;
            double apartmentArea = areaOfSmallestRoom + areaOfSecondRoom + areaOfThirdRoom + areaOfKitchen + areaOfBathroom;
            double areaWithHall = apartmentArea + apartmentArea * 0.05;

            double priceOfApartment = areaWithHall * priceOfSquareMeter;
            Console.WriteLine($"{priceOfApartment:f2}");
        }
    }
}

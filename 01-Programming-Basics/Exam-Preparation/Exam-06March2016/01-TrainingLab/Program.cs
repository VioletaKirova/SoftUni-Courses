using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_TrainingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            double h = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());

            double heightInCm = h * 100;
            double widthInCm = w * 100;

            double rows = Math.Floor(heightInCm / 120);
            double cols = Math.Floor((widthInCm - 100) / 70);

            double workPlaces = rows * cols - 3;
            Console.WriteLine(workPlaces);       
        }
    }
}

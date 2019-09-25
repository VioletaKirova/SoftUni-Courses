using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GameOfIntervals
{
    class Program
    {
        static void Main(string[] args)
        {
            int moves = int.Parse(Console.ReadLine());

            double allPoints = 0.0;

            double firstSum = 0.0;
            double secondSum = 0.0;
            double thirsSum = 0.0;
            double forthSum = 0.0;
            double fifthSum = 0.0;
            double sixthSum = 0.0;

            for (int i = 0; i < moves; i++)
            {
                double number = double.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    allPoints += number * 0.2;
                    firstSum++;
                }
                else if (number >= 10 && number <= 19)
                {
                    allPoints += number * 0.3;
                    secondSum++;

                }
                else if (number >= 20 && number <= 29)
                {
                    allPoints += number * 0.4;
                    thirsSum++;
                }
                else if (number >= 30 && number <= 39)
                {
                    allPoints += 50;
                    forthSum++;
                }
                else if (number >= 40 && number <= 50)
                {
                    allPoints += 100;
                    fifthSum++;
                }
                else
                {
                    allPoints = allPoints / 2;
                    sixthSum++;
                }
            }

            double firstPercent = firstSum / moves * 100;
            double secondPercent = secondSum / moves * 100;
            double thirdPercent = thirsSum / moves * 100;
            double forthPercent = forthSum / moves * 100;
            double fifthPercent = fifthSum / moves * 100;
            double sixthPercent = sixthSum / moves * 100;

            Console.WriteLine($"{allPoints:f2}");
            Console.WriteLine($"From 0 to 9: {firstPercent:f2}%");
            Console.WriteLine($"From 10 to 19: {secondPercent:f2}%");
            Console.WriteLine($"From 20 to 29: {thirdPercent:f2}%");
            Console.WriteLine($"From 30 to 39: {forthPercent:f2}%");
            Console.WriteLine($"From 40 to 50: {fifthPercent:f2}%");
            Console.WriteLine($"Invalid numbers: {sixthPercent:f2}%");
        }
    }
}

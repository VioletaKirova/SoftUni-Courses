using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ThreeBrothers
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstTime = double.Parse(Console.ReadLine());
            double secondTime = double.Parse(Console.ReadLine());
            double thirdTime = double.Parse(Console.ReadLine());
            double timeForFishing = double.Parse(Console.ReadLine());

            double timeForCleaning = 1 / (1 / firstTime + 1 / secondTime + 1 / thirdTime);
            double cleaningWithBreak = timeForCleaning + timeForCleaning * 0.15;

            Console.WriteLine($"Cleaning time: {cleaningWithBreak:f2}");

            if (timeForFishing > cleaningWithBreak)
            {
                double timeLeft = Math.Floor(timeForFishing - cleaningWithBreak);
                Console.WriteLine($"Yes, there is a surprise - time left -> {timeLeft} hours.");
            }
            else 
            {
                double shortageOfTime = Math.Ceiling(cleaningWithBreak - timeForFishing);
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {shortageOfTime} hours.");
            }
        }
    }
}

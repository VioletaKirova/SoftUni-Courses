using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int timeSum = firstTime + secondTime + thirdTime;
            int minutes = 0;
            int seconds = 0;

            if (timeSum <= 59)
            {
                seconds = timeSum;
            }
            else if (timeSum >= 60 && timeSum <= 119)
            {
                minutes = 1;
                seconds = timeSum - 60;
            }
            else if (timeSum >= 120 && timeSum <= 179)
            {
                minutes = 2;
                seconds = timeSum - 120;
            }

            Console.WriteLine($"{minutes}:{seconds:00}");

        }
    }
}

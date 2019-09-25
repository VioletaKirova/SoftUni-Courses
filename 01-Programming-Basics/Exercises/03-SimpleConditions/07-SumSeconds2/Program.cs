using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SumSeconds2
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int timeSum = firstTime + secondTime + thirdTime;

            int minutes = timeSum / 60;
            int seconds = timeSum % 60;

            Console.WriteLine($"{minutes}:{seconds:00}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WorldRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentRecord = double.Parse(Console.ReadLine());
            double meters = double.Parse(Console.ReadLine());
            double secondsPerMeter = double.Parse(Console.ReadLine());

            double seconds = meters * secondsPerMeter;
            double extraSeconds = (Math.Floor(meters / 15)) * 12.5;

            double swimmersSeconds = seconds + extraSeconds;
            double neededSeconds = swimmersSeconds - currentRecord;

            if (swimmersSeconds < currentRecord)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {swimmersSeconds:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {neededSeconds:f2} seconds slower.");
            }
            
        }
    }
}

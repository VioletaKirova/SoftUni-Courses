using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            int examTime = examHour * 60 + examMin;
            int arrivalTime = arrivalHour * 60 + arrivalMin;
            int hoursForOutput = 0;
            int minsForOutput = 0;

            if (arrivalTime > examTime)
            {
                Console.WriteLine("Late");

                if (arrivalTime - examTime >= 60)
                {
                    hoursForOutput = (arrivalTime - examTime) / 60;
                    minsForOutput = (arrivalTime - examTime) % 60;
                    Console.WriteLine($"{hoursForOutput}:{minsForOutput:00} hours after the start");
                }
                else if (arrivalTime - examTime < 60)
                {
                    minsForOutput = arrivalTime - examTime;
                    Console.WriteLine($"{minsForOutput:00} minutes after the start");
                }
            }
            else if (arrivalTime == examTime || (examTime - arrivalTime <= 30))
            {
                Console.WriteLine("On time");

                if (examTime - arrivalTime <= 30  )
                {
                    minsForOutput = examTime - arrivalTime;
                    Console.WriteLine($"{minsForOutput} minutes before the start");
                }
            }
            else if (examTime - arrivalTime > 30)
            {
                Console.WriteLine("Early");

                if (examTime - arrivalTime >= 60)
                {
                    hoursForOutput = (examTime - arrivalTime) / 60;
                    minsForOutput = (examTime - arrivalTime) % 60;
                    Console.WriteLine($"{hoursForOutput}:{minsForOutput:00} hours before the start");
                }
                else if (examTime - arrivalTime < 60)
                {
                    minsForOutput = (examTime - arrivalTime) % 60;
                    Console.WriteLine($"{minsForOutput:00} minutes before the start");
                }
            }
        }
    }
}

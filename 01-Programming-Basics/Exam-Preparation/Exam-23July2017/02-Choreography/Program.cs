using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            int steps = int.Parse(Console.ReadLine());
            int dancers = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double stepsNeededPerDay = steps / days;
            double percentageAbleToDo = Math.Ceiling(stepsNeededPerDay / steps * 100);
            double persentagePerDancer = percentageAbleToDo / dancers;

            if (percentageAbleToDo <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {persentagePerDancer:f2}%.");
            }
            else if (percentageAbleToDo > 13)
            {
                Console.WriteLine($"No, They will not succeed in that goal! Required {persentagePerDancer:f2}% steps to be learned per day.");
            }
        }
    }
}

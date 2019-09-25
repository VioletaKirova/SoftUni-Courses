using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WorkHours
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededHours = double.Parse(Console.ReadLine());
            double workers = double.Parse(Console.ReadLine());
            double workDays = double.Parse(Console.ReadLine());

            double workingHours = workers * workDays * 8;

            if (workingHours > neededHours)
            {
                double hoursLeft = workingHours - neededHours;

                Console.WriteLine($"{hoursLeft} hours left");
            }
            else
            {
                double needed = neededHours - workingHours;
                double penalties = needed * workDays;

                Console.WriteLine($"{needed} overtime");
                Console.WriteLine($"Penalties: {penalties}");
            }
        }
    }
}

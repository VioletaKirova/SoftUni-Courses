using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    class Program
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int allWorkDays = int.Parse(Console.ReadLine());
            int employees = int.Parse(Console.ReadLine());

            double workDays = allWorkDays - allWorkDays * 0.1;
            double workHours = workDays * 8;
            double workHoursOverTime = employees * 2 * allWorkDays;

            double hoursForProject = Math.Floor(workHours + workHoursOverTime);
            double extraOrNeeded = Math.Abs(hoursForProject - neededHours);
           
            if (neededHours <= hoursForProject)
            {
                Console.WriteLine($"Yes!{extraOrNeeded} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{extraOrNeeded} hours needed.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days = 
            { 
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int i = int.Parse(Console.ReadLine());

            if (i >= 1 && i <= 7)
                Console.WriteLine(days[i - 1]);
            else
                Console.WriteLine("Invalid day!");
        }
    }
}

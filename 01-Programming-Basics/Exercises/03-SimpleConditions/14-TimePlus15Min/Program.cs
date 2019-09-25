using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_TimePlus15Min
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int mins = int.Parse(Console.ReadLine());

            if (mins + 15 >= 60)
            {
                hours++;
                mins = (mins + 15) - 60;
            }
            else if (mins + 15 < 60)
            {
                mins += 15;
            }

            if (hours == 24)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{mins:00}");
        }
    }
}

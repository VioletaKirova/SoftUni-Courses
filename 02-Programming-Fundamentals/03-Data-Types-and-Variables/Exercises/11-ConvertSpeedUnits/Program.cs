using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            uint meters = uint.Parse(Console.ReadLine());
            byte hours = byte.Parse(Console.ReadLine());
            byte minutes = byte.Parse(Console.ReadLine());
            byte seconds = byte.Parse(Console.ReadLine());

            uint time = (uint)(hours * 3600 + minutes * 60 + seconds);

            float metersPerSecond = (float)meters / time;
            Console.WriteLine(metersPerSecond);

            float kmPerHour = ((float)meters / 1000) / ((float)time / 3600);
            Console.WriteLine(kmPerHour);

            float milesPerHour = ((float)meters / 1609) / ((float)time / 3600);
            Console.WriteLine(milesPerHour);
        }
    }
}

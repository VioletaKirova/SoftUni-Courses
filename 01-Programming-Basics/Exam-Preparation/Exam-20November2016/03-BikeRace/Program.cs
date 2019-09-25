using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BikeRace
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniors = int.Parse(Console.ReadLine());
            int seniors = int.Parse(Console.ReadLine());
            string route = Console.ReadLine().ToLower();

            double juniorFee = 0.0;
            double seniorFee = 0.0;

            double sum = 0.0;

            if (route == "trail")
            {
                juniorFee = juniors * 5.5;
                seniorFee = seniors * 7;
            }
            else if (route == "cross-country")
            {
                juniorFee = juniors * 8;
                seniorFee = seniors * 9.5;
            }
            else if (route == "downhill")
            {
                juniorFee = juniors * 12.25;
                seniorFee = seniors * 13.75;
            }
            else if (route == "road")
            {
                juniorFee = juniors * 20;
                seniorFee = seniors * 21.5;
            }

            sum = juniorFee + seniorFee;

            if (route == "cross-country" && (juniors + seniors >= 50))
            {
                sum -= sum * 0.25;
            }

            sum -= sum * 0.05;

            Console.WriteLine($"{sum:f2}");
        }
    }
}

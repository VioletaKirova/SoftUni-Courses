using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsAtHome = double.Parse(Console.ReadLine());

            double gamesOnHolidays = holidays * 2 / 3;
            double gamesInSofia = (48 - weekendsAtHome) * 3/4;

            double allGames = gamesOnHolidays + gamesInSofia + weekendsAtHome;

            if (year == "leap")
            {
                allGames += allGames * 0.15;
                Console.WriteLine(Math.Floor(allGames));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(allGames));
            }

        }
    }
}

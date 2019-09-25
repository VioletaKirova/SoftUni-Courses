using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pricesArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string[] lootAndExpencess = new string[2];
            int earnings = 0;
            int expenses = 0;

            for (int i = 0; ; i++)
            {
                lootAndExpencess = Console.ReadLine().Split(' ').ToArray();

                if (lootAndExpencess[0] == "Jail" && lootAndExpencess[1] == "Time")
                {
                    break;
                }

                for (int j = 0; j < lootAndExpencess[0].Length; j++)
                {
                    if (lootAndExpencess[0][j] == '%')
                    {
                        earnings += pricesArr[0];
                    }
                    else if (lootAndExpencess[0][j] == '$')
                    {
                        earnings += pricesArr[1];
                    }
                }

                expenses += int.Parse(lootAndExpencess[1]);
            }    
            
            int totalEarnedOrLost = Math.Abs(earnings - expenses);

            if (earnings >= expenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarnedOrLost}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {totalEarnedOrLost}.");
            }
        }
    }
}
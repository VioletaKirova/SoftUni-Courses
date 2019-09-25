using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TriplesOfLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num1 = 0; num1 <= n - 1; num1++)
            {
                for (int num2 = 0; num2 <= n - 1; num2++)
                {
                    for (int num3 = 0; num3 <= n - 1; num3++)
                    {
                        char firstLetter = (char)('a' + num1);
                        char secondLetter = (char)('a' + num2);
                        char thirdLetter = (char)('a' + num3);
                        Console.WriteLine($"{firstLetter}{secondLetter}{thirdLetter}");
                    }
                }
            }
        }
    }
}

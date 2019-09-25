using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GroupName
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());
            char forthLetter = char.Parse(Console.ReadLine());
            int number = int.Parse(Console.ReadLine());
            int count = 0;

            for (char i = 'A'; i <= firstLetter; i++)
            {
                for (char l = 'a'; l <= secondLetter; l++)
                {
                    for (char j = 'a'; j <= thirdLetter; j++)
                    {
                        for (char h = 'a'; h <= forthLetter; h++)
                        {
                            for (int p = 0; p <= number; p++)
                            {
                                count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine(count - 1);
        }
    }
}

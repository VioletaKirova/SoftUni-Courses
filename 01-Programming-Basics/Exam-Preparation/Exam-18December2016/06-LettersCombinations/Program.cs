using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_LettersCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());

            int count = 0;

            for (char i = first; i <= second; i++)
            {
                for (char j = first; j <= second; j++)
                {
                    for (char h = first; h <= second; h++)
                    {
                        if (i != third && j != third && h != third)
                        {
                            Console.Write($"{i}{j}{h} ");

                            count++;
                        }
                    }
                }
            }

            Console.Write(count);
        }
    }
}

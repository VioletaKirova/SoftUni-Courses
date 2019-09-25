using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_StringConcatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimiter = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            sbyte n = sbyte.Parse(Console.ReadLine());
            string output = "";

            for (sbyte i = 1; i <= n; i++)
            {
                string word = Console.ReadLine();
                
                if (evenOrOdd == "odd")
                {
                    if (i == 1)
                        output += $"{word}";
                    else if (i % 2 != 0)
                        output += $"{delimiter}{word}";
                }
                else if (evenOrOdd == "even")
                {
                    if (i == 2)
                        output += $"{word}";
                    else if (i % 2 == 0)
                        output += $"{delimiter}{word}";
                }
            }

            Console.WriteLine(output);
        }
    }
}

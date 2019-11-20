using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_MakeAWord
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte n = sbyte.Parse(Console.ReadLine());
            string output = "";

            for (sbyte i = 0; i < n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                output += character;
            }

            Console.WriteLine($"The word is: {output}");
        }
    }
}

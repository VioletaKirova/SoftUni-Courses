using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_PrintPartOfASCIITable
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingIndex = int.Parse(Console.ReadLine());
            int endingIndex = int.Parse(Console.ReadLine());

            char firstChar = (char)(startingIndex);
            char lastChar = (char)(endingIndex);

            for (char i = firstChar; i <= lastChar; i++)
            {
                Console.Write($"{i} ");
            }
        }
    }
}

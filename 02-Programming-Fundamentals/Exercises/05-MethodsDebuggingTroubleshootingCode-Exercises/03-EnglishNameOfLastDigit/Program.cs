using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_EnglishNameOfLastDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            string englishName = PrintEnglishName(number);
            Console.WriteLine(englishName);
        }

        static string PrintEnglishName(long number)
        {
            string englishName = "";

            switch (Math.Abs(number) % 10)
            {
                case 0: englishName = "zero"; break;
                case 1: englishName = "one"; break;
                case 2: englishName = "two"; break;
                case 3: englishName = "three"; break;
                case 4: englishName = "four"; break;
                case 5: englishName = "five"; break;
                case 6: englishName = "six"; break;
                case 7: englishName = "seven"; break;
                case 8: englishName = "eight"; break;
                case 9: englishName = "nine"; break;
            }

            return englishName;
        }
    }
}

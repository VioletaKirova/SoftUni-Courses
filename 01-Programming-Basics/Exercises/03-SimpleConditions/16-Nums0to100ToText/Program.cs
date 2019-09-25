using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_Nums0to100ToText
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int firstDigit = num / 10;
            int secondDigit = num % 10;

            if (num < 0 || num > 100)
            {
                Console.WriteLine("invalid number");
            }
            else
            {
                if (num == 0) Console.WriteLine("zero");
                else if (num == 1) Console.WriteLine("one");
                else if (num == 2) Console.WriteLine("two");
                else if (num == 3) Console.WriteLine("three");
                else if (num == 4) Console.WriteLine("four");
                else if (num == 5) Console.WriteLine("five");
                else if (num == 6) Console.WriteLine("six");
                else if (num == 7) Console.WriteLine("seven");
                else if (num == 8) Console.WriteLine("eight");
                else if (num == 9) Console.WriteLine("nine");
                else if (num == 10) Console.WriteLine("ten");
                else if (num == 11) Console.WriteLine("eleven");
                else if (num == 12) Console.WriteLine("twelve");
                else if (num == 13) Console.WriteLine("thirteen");
                else if (num == 14) Console.WriteLine("fourteen");
                else if (num == 15) Console.WriteLine("fifteen");
                else if (num == 16) Console.WriteLine("sixteen");
                else if (num == 17) Console.WriteLine("seventeen");
                else if (num == 18) Console.WriteLine("eighteen");
                else if (num == 19) Console.WriteLine("nineteen");
                else if (num == 100) Console.WriteLine("one hundred");

                if (num > 19 && num != 100)
                {
                    if (firstDigit == 2) Console.Write("twenty");
                    else if (firstDigit == 3) Console.Write("thirty");
                    else if (firstDigit == 4) Console.Write("forty");
                    else if (firstDigit == 5) Console.Write("fifty");
                    else if (firstDigit == 6) Console.Write("sixty");
                    else if (firstDigit == 7) Console.Write("seventy");
                    else if (firstDigit == 8) Console.Write("eighty");
                    else if (firstDigit == 9) Console.Write("ninety");
                }

                if (num > 19 && num != 100)
                {
                    if (secondDigit == 1) Console.WriteLine(" one");
                    else if (secondDigit == 2) Console.WriteLine(" two");
                    else if (secondDigit == 3) Console.WriteLine(" three");
                    else if (secondDigit == 4) Console.WriteLine(" four");
                    else if (secondDigit == 5) Console.WriteLine(" five");
                    else if (secondDigit == 6) Console.WriteLine(" six");
                    else if (secondDigit == 7) Console.WriteLine(" seven");
                    else if (secondDigit == 8) Console.WriteLine(" eight");
                    else if (secondDigit == 9) Console.WriteLine(" nine");
                }
            }
        }
    }
}

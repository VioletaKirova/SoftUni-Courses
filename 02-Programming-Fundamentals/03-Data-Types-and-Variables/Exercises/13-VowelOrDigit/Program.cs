using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_VowelOrDigit
{
    class Program
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (symbol == 'a' || symbol == 'y' || symbol == 'o' || symbol == 'u' || symbol == 'e' || symbol == 'i')
                Console.WriteLine("vowel");
            else if (symbol == '0' || symbol == '1' || symbol == '2' || symbol == '3' || symbol == '4' || symbol == '5'
                || symbol == '6' || symbol == '7' || symbol == '8' || symbol == '9')
            Console.WriteLine("digit");

            //else if (char.IsNumber(symbol))
            //{
            //    Console.WriteLine("digit");
            //}

            //else if (symbol >= 48 && symbol <= 57)
            //{
            //    Console.WriteLine("digit");
            //}

            else
                Console.WriteLine("other");
        }
    }
}

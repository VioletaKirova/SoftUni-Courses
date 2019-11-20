using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_NumbersInReversedOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string reversedNumber = GiveReversedNumber(number);
            Console.WriteLine(reversedNumber);
        }

        static string GiveReversedNumber(string number)
        {
            char[] arrString = number.ToCharArray();
            Array.Reverse(arrString);
            return new string(arrString);
        }
    }
}

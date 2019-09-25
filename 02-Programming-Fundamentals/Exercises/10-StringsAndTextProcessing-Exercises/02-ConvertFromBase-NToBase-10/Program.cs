using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Convert_from_Base_N_to_Base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Trim().Split();
            int baseN = int.Parse(input[0]);
            char[] number = input[1].ToCharArray();
            BigInteger result = new BigInteger(0);

            for (int i = 0; i < number.Length; i++)
            {
                int currentNum = (int)Char.GetNumericValue(number[i]);
                result += currentNum * BigInteger.Pow(baseN, number.Length - i - 1);
            }

            Console.WriteLine(result);
        }
    }
}
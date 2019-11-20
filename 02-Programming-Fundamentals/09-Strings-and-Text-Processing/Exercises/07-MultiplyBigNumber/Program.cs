using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] num1 = Console.ReadLine().TrimStart('0').ToArray();
            sbyte num2 = sbyte.Parse(Console.ReadLine());

            if (num1[0].ToString() == "0" || num2 == 0 || num1[0].ToString() == "")
            {
                Console.WriteLine(0);
                return;
            }

            sbyte product = 0;
            sbyte remainder = 0;
            sbyte addition = 0;
            StringBuilder result = new StringBuilder();

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                product = (sbyte)(sbyte.Parse(num1[i].ToString()) * num2 + addition);
                remainder = (sbyte)(product % 10);
                addition = (sbyte)(product / 10);
                result.Append(remainder);              

                if (i == 0 && addition != 0)
                {
                    result.Append(addition);
                }
            }

            char[] output = result.ToString().ToCharArray();
            Array.Reverse(output);
            Console.WriteLine(string.Join("", output));
        }
    }
}
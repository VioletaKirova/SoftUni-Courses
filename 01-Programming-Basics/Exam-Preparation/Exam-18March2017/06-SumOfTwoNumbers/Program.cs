using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingNum = int.Parse(Console.ReadLine());
            int endingNum = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());

            int count = 0;
            bool magicNumReached = false;

            int firstNum = 0;
            int secondNum = 0;

            for (int i = startingNum; i <= endingNum; i++)
            {
                for (int h = startingNum; h <= endingNum; h++)
                {
                    count++;

                    if (i + h == magicNum)
                    {
                        firstNum = i;
                        secondNum = h;

                        magicNumReached = true;
                        break;
                    }
                }

                if (magicNumReached)
                {
                    break;
                }
            }

            if (!magicNumReached)
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNum}");
            }
            else
            {
                Console.WriteLine($"Combination N:{count} ({firstNum} + {secondNum} = {magicNum})");
            }
        }
    }
}

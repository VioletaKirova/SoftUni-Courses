using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LargestCommonEnd2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split(' ').ToArray();
            string[] secondArr = Console.ReadLine().Split(' ').ToArray();

            int shorterArrLength = Math.Min(firstArr.Length, secondArr.Length);

            int countLeftToRight = 0;
            int countRightToLeft = 0;

            for (int i = 0; i < shorterArrLength; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    countLeftToRight++;
                }
            }

            for (int j = 0; j < shorterArrLength; j++)
            {
                if (firstArr[firstArr.Length - 1 - j] == secondArr[secondArr.Length - 1 - j])
                {
                    countRightToLeft++;
                }
            }

            if (countLeftToRight == 0 && countRightToLeft == 0)
                Console.WriteLine("0");
            else if (countLeftToRight > countRightToLeft)
                Console.WriteLine(countLeftToRight);
            else
                Console.WriteLine(countRightToLeft);
        }
    }
}

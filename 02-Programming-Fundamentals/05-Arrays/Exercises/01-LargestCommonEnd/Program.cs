using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] wordsFirst = Console.ReadLine().Split(' ').ToArray();
            string[] wordsSecond = Console.ReadLine().Split(' ').ToArray();
            int countLeftRight = 0;
            int countRightLeft = 0;

            for (int i = 0; i < wordsFirst.Length && i < wordsSecond.Length; i++)
            {
                if (wordsFirst[i] == wordsSecond[i])
                {
                    countLeftRight++;
                }
            }

            for (int j = 0; j < wordsFirst.Length && j < wordsSecond.Length; j++)
            {
                if (wordsFirst[wordsFirst.Length - 1 - j] == wordsSecond[wordsSecond.Length - 1 - j])
                {
                    countRightLeft++;
                }
            }

            Console.WriteLine(countRightLeft > countLeftRight ? countRightLeft : countLeftRight);
        }
    }
}

using System;
using System.Linq;

namespace _02_CryptoMaster2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestSeq = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int step = 1; step < numbers.Length; step++)
                {
                    int currentIndex = i;
                    int nextIndex = (currentIndex + step) % numbers.Length;

                    int currentSeq = 1;

                    while (numbers[currentIndex] < numbers[nextIndex])
                    {
                        currentSeq++;
                       
                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % numbers.Length;
                    }

                    if (longestSeq < currentSeq)
                    {
                        longestSeq = currentSeq;
                    }
                }
            }

            Console.WriteLine(longestSeq);
        }
    }
}

using System;
using System.Linq;

namespace _02_CryptoMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int longestRun = 1;

            for (int i = 0; i < array.Length; i++)
            {
                for (int step = 1; step < array.Length; step++)
                {
                    int currentIndex = i;

                    int nextIndex = (currentIndex + step) % array.Length;
                    int currentRun = 1;

                    while (array[nextIndex] > array[currentIndex])
                    {
                        currentRun++;
                        if (currentRun > longestRun)
                        {
                            longestRun = currentRun;
                        }

                        currentIndex = nextIndex;
                        nextIndex = (currentIndex + step) % array.Length;
                    }
                }
            }
        }
    }
}

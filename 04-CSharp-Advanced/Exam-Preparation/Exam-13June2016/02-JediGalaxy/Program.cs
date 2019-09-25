using System;
using System.Linq;

namespace _02_JediGalaxy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[][] jaggedArray = new int[dimensions[0]][];

            int value = -1;

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new int[dimensions[1]];

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {               
                    jaggedArray[row][col] = ++value;
                }
            }

            long ivoSum = 0;

            string input = Console.ReadLine();

            while (input != "Let the Force be with you")
            {
                int[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evilArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ivoRow = inputArgs[0];
                int ivoCol = inputArgs[1];

                int evilRow = evilArgs[0];
                int evilCol = evilArgs[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (IsInside(evilRow, evilCol, jaggedArray))
                    {
                        jaggedArray[evilRow][evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol < jaggedArray[0].Length)
                {
                    if (IsInside(ivoRow, ivoCol, jaggedArray))
                    {
                        ivoSum += jaggedArray[ivoRow][ivoCol];
                    }

                    ivoRow--;
                    ivoCol++;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(ivoSum);
        }

        private static bool IsInside(int row, int col, int[][] jaggedArray)
        {
            return row >= 0 &&
                row < jaggedArray.Length &&
                col >= 0 &&
                col < jaggedArray[row].Length;
        }
    }
}

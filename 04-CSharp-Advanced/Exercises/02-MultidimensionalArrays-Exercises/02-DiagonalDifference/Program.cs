using System;
using System.Linq;

namespace _02_DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int primaryDiagonalSum = 0;

            int secondaryDiagonalSum = 0;

            int colIndex = matrix.GetLength(1) - 1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int primaryNum = matrix[row, row];

                primaryDiagonalSum += primaryNum;

                int secondaryNum = matrix[row, colIndex];

                secondaryDiagonalSum += secondaryNum;

                colIndex--;
            }

            int difference = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);

            Console.WriteLine(difference);
        }
    }
}

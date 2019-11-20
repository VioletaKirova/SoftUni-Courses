using System;
using System.Collections.Generic;
using System.Linq;

namespace _12_StringMatrixRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rotationInfo = Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int degrees = int.Parse(rotationInfo[1]) % 360;

            string input = Console.ReadLine();

            int maxInputLen = 0;

            List<string> inputList = new List<string>();

            while (input != "END")
            {
                inputList.Add(input);

                if (input.Length > maxInputLen)
                {
                    maxInputLen = input.Length;
                }

                input = Console.ReadLine();
            }

            char[][] matrix = new char[inputList.Count][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[maxInputLen];

                string currentListItem = inputList[row];

                string neededEmptySpaces = new string(' ', maxInputLen - currentListItem.Length);

                string currentRow = currentListItem + neededEmptySpaces;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentRow[col];
                }
            }

            if (degrees == 0)
            {
                RotateBy0(matrix);
            }
            else if (degrees == 90)
            {
                RotateBy90(matrix);
            }
            else if (degrees == 180)
            {
                RotateBy180(matrix);
            }
            else if (degrees == 270)
            {
                RotateBy270(matrix);
            }
        }

        private static void RotateBy270(char[][] matrix)
        {
            for (int col = matrix[0].Length - 1; col >= 0; col--)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void RotateBy90(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void RotateBy180(char[][] matrix)
        {
            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                for (int col = matrix[row].Length - 1; col >= 0; col--)
                {
                    Console.Write(matrix[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void RotateBy0(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}

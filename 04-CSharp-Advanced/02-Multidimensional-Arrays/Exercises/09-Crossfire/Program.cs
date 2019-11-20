using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_Crossfire
{
    // 10/100

    class Program
    {
        static List<List<int>> matrix;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            GetMatrix(rows, cols);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Nuke it from orbit")
                {
                    PrintMatrix();

                    break;
                }
                else
                {
                    int[] coordinates = ParseCoordinates(input);

                    int row = coordinates[0];
                    int col = coordinates[1];
                    int radius = coordinates[2];

                    DestroyCells(row, col, radius);
                }
            }
        }

        private static void DestroyCells(int row, int col, int radius)
        {
            if (IsInside(row, col))
            {
                List<int> currentRow = matrix[row];

                for (int c = col - radius; c <= col + radius; c++)
                {
                    if (IsInside(row, c))
                    {
                        currentRow.RemoveAt(c);
                        c--;
                    }
                }

                for (int r = row - radius; r <= row + radius; r++)
                {
                    if (IsInside(r, col))
                    {
                        matrix[r].RemoveAt(col);
                    }
                }

                if (currentRow.Count == 0)
                {
                    matrix.RemoveAt(row);
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Count && col >= 0 && col < matrix[row].Count;
        }

        private static int[] ParseCoordinates(string input)
        {
            return input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        private static void GetMatrix(int rows, int cols)
        {
            matrix = new List<List<int>>(rows);

            int number = 1;

            for (int row = 0; row < rows; row++)
            {
                matrix.Add(new List<int>());

                for (int col = 0; col < cols; col++)
                {
                    matrix[row].Add(number);
                    number++;
                }
            }
        }
    }
}

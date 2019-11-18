using System;
using System.Collections.Generic;
using System.Linq;

namespace _07_LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());

            int[][] jaggedArray1 = new int[rowCount][];
            int[][] jaggedArray2 = new int[rowCount][];

            GetJaggedArray(jaggedArray1);
            GetJaggedArray(jaggedArray2);

            int rowLength = jaggedArray1[0].Length + jaggedArray2[0].Length;

            bool arraysFit = CheckRowLength(jaggedArray1, jaggedArray2, rowLength);

            if (arraysFit)
            {
                ReverseAndCombineArray(rowCount, jaggedArray1, jaggedArray2);
            }
            else
            {
                PrintNumberOfCells(rowCount, jaggedArray1, jaggedArray2);
            }
        }

        private static void ReverseAndCombineArray(int rowCount, int[][] jaggedArray1, int[][] jaggedArray2)
        {
            for (int row = 0; row < rowCount; row++)
            {
                Stack<int> jaggedArray2Row = new Stack<int>(jaggedArray2[row]);

                for (int col = 0; col < jaggedArray2[row].Length; col++)
                {
                    jaggedArray2[row][col] = jaggedArray2Row.Pop();
                }

                PrintMatchedRow(jaggedArray1, jaggedArray2, row);
            }
        }

        private static void PrintNumberOfCells(int rowCount, int[][] jaggedArray1, int[][] jaggedArray2)
        {
            int totalCells = 0;

            for (int row = 0; row < rowCount; row++)
            {
                totalCells += (jaggedArray1[row].Length + jaggedArray2[row].Length);
            }

            Console.WriteLine($"The total number of cells is: {totalCells}");
        }

        private static void PrintMatchedRow(int[][] jaggedArray1, int[][] jaggedArray2, int row)
        {
            Console.Write("[");

            for (int col = 0; col < jaggedArray1[row].Length; col++)
            {
                Console.Write($"{jaggedArray1[row][col]}, ");
            }

            for (int col = 0; col < jaggedArray2[row].Length; col++)
            {
                if (col == jaggedArray2[row].Length - 1)
                {
                    Console.Write($"{jaggedArray2[row][col]}");
                }
                else
                {
                    Console.Write($"{jaggedArray2[row][col]}, ");
                }
            }

            Console.Write("]");
            Console.WriteLine();
        }

        private static bool CheckRowLength(int[][] jaggedArray1, int[][] jaggedArray2, int rowLength)
        {
            bool arraysFit = true;

            for (int row = 1; row < jaggedArray1.Length; row++)
            {
                if (jaggedArray1[row].Length + jaggedArray2[row].Length != rowLength)
                {
                    arraysFit = false;
                    break;
                }
            }

            return arraysFit;
        }

        private static void GetJaggedArray(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                jaggedArray[row] = currentRow;
            }
        }
    }
}

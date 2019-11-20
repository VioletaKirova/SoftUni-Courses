using System;
using System.Linq;

namespace _05_RubiksMatrix
{
    // Unfinished

    class Program
    {      
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[rowsAndCols[0], rowsAndCols[1]];

            int number = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    number++;

                    matrix[row, col] = number;
                }
            }

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                int rowOrCol = int.Parse(input[0]);
                string command = input[1];
                int moves = int.Parse(input[2]);

                if (command == "left")
                {
;
                }
                else if (command == "right")
                {

                }
                else if (command == "up")
                {

                }
                else if (command == "down")
                {

                }
            }
        }
    }
}

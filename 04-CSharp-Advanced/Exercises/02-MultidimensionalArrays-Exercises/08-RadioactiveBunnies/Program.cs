using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_RadioactiveBunnies
{
    // 0/100

    class Program
    {       
        static int playerRow;

        static int playerCol;

        static bool playerIsDead;

        static bool playerWon;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];

            ReadMatrix(matrix, cols);

            List<int[]> bunnyIndexes = new List<int[]>();

            FillBunnyList(matrix, bunnyIndexes);

            playerIsDead = false;

            playerWon = false;

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                int[] targetRowCol = ReadDirection(directions[i]);

                int targetRow = targetRowCol[0];
                int targetCol = targetRowCol[1];

                if (IsInside(targetRow, targetCol, matrix))
                {
                    CheckCell(matrix, targetRow, targetCol);
                }
                else
                {
                    playerWon = true;

                    PrintMatrix(matrix);

                    Console.WriteLine($"won: {playerRow} {playerCol}");
                }

                SpreadBunnies(matrix, bunnyIndexes);

                if (playerWon)
                {
                    break;
                }

                if (playerIsDead)
                {
                    PrintMatrix(matrix);

                    Console.WriteLine($"dead: {playerRow} {playerCol}");

                    break;
                }
            }
        }

        private static void FillBunnyList(char[][] matrix, List<int[]> bunnyIndexes)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        int[] bunnyIndex = new int[] { row, col };

                        bunnyIndexes.Add(bunnyIndex);
                    }
                }
            }
        }

        private static void SpreadBunnies(char[][] matrix, List<int[]> bunnyIndexes)
        {
            for (int i = 0; i < bunnyIndexes.Count; i++)
            {
                int row = bunnyIndexes[i][0];
                int col = bunnyIndexes[i][1];

                if (IsInside(row, col - 1, matrix))
                {
                    CheckForPlayer(matrix, row, col - 1);
                }

                if (IsInside(row, col + 1, matrix))
                {
                    CheckForPlayer(matrix, row, col + 1);
                }

                if (IsInside(row - 1, col, matrix))
                {
                    CheckForPlayer(matrix, row - 1, col);
                }

                if (IsInside(row + 1, col, matrix))
                {
                    CheckForPlayer(matrix, row + 1, col);
                }

                bunnyIndexes.Clear();
                FillBunnyList(matrix, bunnyIndexes);
            }
        }

        private static void CheckForPlayer(char[][] matrix, int row, int col)
        {
            if (matrix[row][col] != 'P' && matrix[row][col] != 'B')
            {
                matrix[row][col] = 'B';
            }
            else
            {
                matrix[row][col] = 'B';

                playerIsDead = true;
            }
        }

        private static int[] ReadDirection(char direction)
        {
            int[] targetRowCol = new int[2];

            if (direction == 'R')
            {
                targetRowCol[0] = playerRow;
                targetRowCol[1] = playerCol + 1;
            }
            else if (direction == 'L')
            {
                targetRowCol[0] = playerRow;
                targetRowCol[1] = playerCol - 1;
            }
            else if (direction == 'U')
            {
                targetRowCol[0] = playerRow - 1;
                targetRowCol[1] = playerCol;
            }
            else
            {
                targetRowCol[0] = playerRow + 1;
                targetRowCol[1] = playerCol;
            }

            return targetRowCol;
        }

        private static bool IsInside(int targetRow, int targetCol, char[][] matrix)
        {
            bool isInside = targetRow >= 0 && 
                targetRow < matrix.Length && 
                targetCol >= 0 && 
                targetCol < matrix[0].Length;

            return isInside;
        }

        private static void CheckCell(char[][] matrix, int targetRow, int targetCol)
        {
            if (matrix[targetRow][targetCol] == '.')
            {
                matrix[targetRow][targetCol] = 'P';
                matrix[playerRow][playerCol] = '.';

                playerRow = targetRow;
                playerCol = targetCol;
            }
            else
            {
                matrix[playerRow][playerCol] = '.';

                playerRow = targetRow;
                playerCol = targetCol;

                playerIsDead = true;
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[0].Length; col++)
                {
                    Console.Write($"{matrix[row][col]}");
                }

                Console.WriteLine();
            }
        }

        private static void ReadMatrix(char[][] matrix, int cols)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[cols];

                string input = Console.ReadLine();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = input[col];

                    if (matrix[row][col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}

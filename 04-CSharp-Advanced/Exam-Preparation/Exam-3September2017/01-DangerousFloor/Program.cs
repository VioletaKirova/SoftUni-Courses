using System;
using System.Linq;

namespace _01_DangerousFloor
{
    // 37/100

    class Program
    {
        static int rows = 8;
        static int cols = 8;

        static char[][] matrix;

        static void Main(string[] args)
        {
            matrix = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                char symbol = input[0];

                int row = int.Parse(input[1].ToString());
                int col = int.Parse(input[2].ToString());

                int targetRow = int.Parse(input[4].ToString());
                int targetCol = int.Parse(input[5].ToString());

                if (!IsInside(row,col))
                {
                    Console.WriteLine("There is no such a piece!");
                    input = Console.ReadLine();
                    continue;                  
                }

                if (matrix[row][col] != symbol)
                {
                    Console.WriteLine("There is no such a piece!");
                    input = Console.ReadLine();
                    continue;
                }

                if (symbol == 'K')
                {
                    MoveK(symbol, row, col, targetRow, targetCol);
                }
                else if (symbol == 'R')
                {
                    MoveR(symbol, row, col, targetRow, targetCol);
                }
                else if (symbol == 'B')
                {
                    MoveB(symbol, row, col, targetRow, targetCol);
                }
                else if (symbol == 'Q')
                {
                    MoveQ(symbol, row, col, targetRow, targetCol);
                }
                else if (symbol == 'P')
                {
                    MoveP(symbol, row, col, targetRow, targetCol);
                }

                input = Console.ReadLine();
            }
        }

        private static void MoveP(char symbol, int row, int col, int targetRow, int targetCol)
        {
            bool moveIsValid = false;

            if (row - 1 == targetRow && col == targetCol)
            {
                moveIsValid = true;
            }

            CheckMove(symbol, row, col, targetRow, targetCol, moveIsValid);
        }

        private static void MoveQ(char symbol, int row, int col, int targetRow, int targetCol)
        {
            bool moveIsValid = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                if (r == targetRow && col == targetCol)
                {
                    moveIsValid = true;
                    break;
                }
            }

            if (!moveIsValid)
            {
                for (int c = 0; c < matrix[row].Length; c++)
                {
                    if (row == targetRow && c == targetCol)
                    {
                        moveIsValid = true;
                        break;
                    }
                }
            }

            if (!moveIsValid)
            {
                for (int r = 0; r < matrix.Length; r++)
                {
                    int c = r;

                    if (r == targetRow && c == targetCol)
                    {
                        moveIsValid = true;
                        break;
                    }
                }

                if (!moveIsValid)
                {
                    int c = matrix.Length - 1;

                    for (int r = 0; r < matrix.Length; r++)
                    {
                        if (r == targetRow && c == targetCol)
                        {
                            moveIsValid = true;
                            break;
                        }

                        c--;
                    }
                }
            }

            CheckMove(symbol, row, col, targetRow, targetCol, moveIsValid);
        }

        private static void MoveB(char symbol, int row, int col, int targetRow, int targetCol)
        {
            bool moveIsValid = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                int c = r;

                if (r == targetRow && c == targetCol)
                {
                    moveIsValid = true;
                    break;
                }
            }

            if (!moveIsValid)
            {
                int c = matrix.Length - 1;

                for (int r = 0; r < matrix.Length; r++)
                {
                    if (r == targetRow && c == targetCol)
                    {
                        moveIsValid = true;
                        break;
                    }

                    c--;
                }
            }

            CheckMove(symbol, row, col, targetRow, targetCol, moveIsValid);
        }

        private static void MoveR(char symbol, int row, int col, int targetRow, int targetCol)
        {
            bool moveIsValid = false;

            for (int r = 0; r < matrix.Length; r++)
            {
                if (r == targetRow && col == targetCol)
                {
                    moveIsValid = true;
                    break;
                }
            }

            if (!moveIsValid)
            {
                for (int c = 0; c < matrix[row].Length; c++)
                {
                    if (row == targetRow && c == targetCol)
                    {
                        moveIsValid = true;
                        break;
                    }
                }
            }

            CheckMove(symbol, row, col, targetRow, targetCol, moveIsValid);
        }

        private static void CheckMove(char symbol, int row, int col, int targetRow, int targetCol, bool moveIsValid)
        {
            if (!moveIsValid)
            {
                Console.WriteLine("Invalid move!");
            }
            else
            {
                if (IsInside(targetRow, targetCol))
                {
                    matrix[row][col] = 'x';
                    matrix[targetRow][targetCol] = symbol;
                }
                else
                {
                    Console.WriteLine("Move go out of board!");
                }
            }
        }

        private static void MoveK(char symbol, int row, int col, int targetRow, int targetCol)
        {
            bool moveIsValid = false;

            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if (r == targetRow && c == targetCol)
                    {
                        moveIsValid = true;
                    }
                }

                if (moveIsValid)
                {
                    break;
                }
            }

            CheckMove(symbol, row, col, targetRow, targetCol, moveIsValid);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row <= matrix.Length - 1 &&
                col >= 0 && col <= matrix[row].Length - 1;
        }
    }
}

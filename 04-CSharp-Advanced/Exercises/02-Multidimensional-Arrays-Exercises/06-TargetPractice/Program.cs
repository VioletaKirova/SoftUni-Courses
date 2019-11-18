using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Read();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] matrix = new char[rows][];

            string snake = Console.ReadLine();

            GetMatrix(matrix, cols, snake);

            int[] shotParameters = Read();

            int targetRow = shotParameters[0];
            int targetCol = shotParameters[1];
            int radius = shotParameters[2];

            Shoot(matrix, targetRow, targetCol, radius);

            CollapseElements(matrix);

            PrintMatrix(matrix);
        }

        private static void CollapseElements(char[][] matrix)
        {     
            Queue<char> elements = new Queue<char>(matrix.Length);

            for (int col = 0; col < matrix[0].Length; col++)
            {
                int spaceCounter = 0;

                for (int row = 0; row < matrix.Length; row++)
                {
                    if (matrix[row][col] == ' ')
                    {
                        spaceCounter++;
                    }
                    else
                    {
                        elements.Enqueue(matrix[row][col]);
                    }
                }

                for (int row = 0; row < spaceCounter; row++)
                {
                    matrix[row][col] = ' ';
                }

                for (int row = spaceCounter; row < matrix.Length; row++)
                {
                    matrix[row][col] = elements.Dequeue();
                }

                spaceCounter = 0;
            }
        }

        private static void Shoot(char[][] matrix, int targetRow, int targetCol, int radius)
        {
            bool isShot;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    isShot = Math.Pow(targetRow - row, 2) + Math.Pow(targetCol - col, 2) <= Math.Pow(radius, 2);

                    if (isShot)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static int[] Read()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void GetMatrix(char[][] matrix, int cols, string snake)
        {
            bool isLeft = true;

            int snakeIndex = 0;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if (isLeft)
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        snakeIndex = MoveSnake(matrix, snake, row, snakeIndex, col);
                    }

                    isLeft = false;
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        snakeIndex = MoveSnake(matrix, snake, row, snakeIndex, col);
                    }

                    isLeft = true;
                }

            }
        }

        private static int MoveSnake(char[][] matrix, string snake, int row, int snakeCharIndex, int col)
        {
            matrix[row][col] = snake[snakeCharIndex];

            snakeCharIndex++;

            if (snakeCharIndex > snake.Length - 1)
            {
                snakeCharIndex = 0;
            }

            return snakeCharIndex;
        }
    }
}

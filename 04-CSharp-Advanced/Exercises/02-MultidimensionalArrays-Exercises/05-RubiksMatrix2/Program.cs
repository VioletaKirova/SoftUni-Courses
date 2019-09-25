using System;
using System.Linq;

namespace _05_RubiksMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = input[0];
            int cols = input[1];

            int[][] rubiksMatrix = new int[rows][];
           
            GetMatrix(rubiksMatrix, cols);
        
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                int rowColIndex = int.Parse(command[0]);
                string direction = command[1];
                int moves = int.Parse(command[2]);

                switch (direction)
                {
                    case "up":
                        MoveUp(rubiksMatrix, rowColIndex, moves % rubiksMatrix.Length);
                        break;
                    case "down":
                        MoveDown(rubiksMatrix, rowColIndex, moves % rubiksMatrix.Length);
                        break;
                    case "left":
                        MoveLeft(rubiksMatrix, rowColIndex, moves % rubiksMatrix.Length);
                        break;
                    case "right":
                        MoveRight(rubiksMatrix, rowColIndex, moves % rubiksMatrix.Length);
                        break;
                }
            }

            int counter = 1;

            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                for (int col = 0; col < rubiksMatrix[row].Length; col++)
                {
                    if (rubiksMatrix[row][col] == counter)
                    {
                        Console.WriteLine("No swap required");

                        counter++;
                    }
                    else
                    {
                        Rearrange(rubiksMatrix, row, col, counter);

                        counter++;
                    }
                }
            }

            //PrintMatrix(rubiksMatrix);
        }

        private static void Rearrange(int[][] rubiksMatrix, int row, int col, int counter)
        {
            for (int targetRow = 0; targetRow < rubiksMatrix.Length; targetRow++)
            {
                for (int targetCol = 0; targetCol < rubiksMatrix[targetRow].Length; targetCol++)
                {
                    if (rubiksMatrix[targetRow][targetCol] == counter)
                    {
                        rubiksMatrix[targetRow][targetCol] = rubiksMatrix[row][col];

                        rubiksMatrix[row][col] = counter;

                        Console.WriteLine($"Swap ({row}, {col}) with ({targetRow}, {targetCol})");

                        return;
                    }
                }
            }
        }

        private static void MoveRight(int[][] rubiksMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubiksMatrix[row][rubiksMatrix[row].Length - 1];

                for (int col = rubiksMatrix[row].Length - 1; col > 0; col--)
                {
                    rubiksMatrix[row][col] = rubiksMatrix[row][col - 1];
                }

                rubiksMatrix[row][0] = lastElement;
            }
        }

        private static void MoveLeft(int[][] rubiksMatrix, int row, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubiksMatrix[row][0];

                for (int col = 0; col < rubiksMatrix[row].Length - 1; col++)
                {
                    rubiksMatrix[row][col] = rubiksMatrix[row][col + 1];
                }

                rubiksMatrix[row][rubiksMatrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveDown(int[][] rubiksMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int lastElement = rubiksMatrix[rubiksMatrix.Length - 1][col];

                for (int row = rubiksMatrix.Length - 1; row > 0; row--)
                {
                    rubiksMatrix[row][col] = rubiksMatrix[row - 1][col];
                }

                rubiksMatrix[0][col] = lastElement;
            }
        }
        
        private static void MoveUp(int[][] rubiksMatrix, int col, int moves)
        {
            for (int i = 0; i < moves; i++)
            {
                int firstElement = rubiksMatrix[0][col];

                for (int row = 0; row < rubiksMatrix.Length - 1; row++)
                {
                    rubiksMatrix[row][col] = rubiksMatrix[row + 1][col];
                }

                rubiksMatrix[rubiksMatrix.Length - 1][col] = firstElement;
            }
        }

        private static void GetMatrix(int[][] rubiksMatrix, int cols)
        {
            int element = 1;

            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                rubiksMatrix[row] = new int[cols];

                for (int col = 0; col < rubiksMatrix[row].Length; col++)
                {
                    rubiksMatrix[row][col] = element;

                    element++;
                }
            }
        }

        //private static void PrintMatrix(int[][] rubiksMatrix)
        //{
        //    for (int row = 0; row < rubiksMatrix.Length; row++)
        //    {
        //        Console.WriteLine(String.Join("", rubiksMatrix[row]));
        //    }
        //}
    }
}

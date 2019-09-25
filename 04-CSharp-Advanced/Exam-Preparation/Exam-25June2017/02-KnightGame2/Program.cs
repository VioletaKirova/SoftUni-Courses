using System;

namespace KnightGame
{
    public class KnightGame
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                matrix[row] = new char[n];
                matrix[row] = inputRow;
            }

            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;

            while (true)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col].Equals('K'))
                        {
                            // vertical and left
                            if (IsCellInMatrix(row - 2, col - 1, matrix))
                            {
                                if (matrix[row - 2][col - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical and right
                            if (IsCellInMatrix(row - 2, col + 1, matrix))
                            {
                                if (matrix[row - 2][col + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical and left
                            if (IsCellInMatrix(row + 2, col - 1, matrix))
                            {
                                if (matrix[row + 2][col - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical and right
                            if (IsCellInMatrix(row + 2, col + 1, matrix))
                            {
                                if (matrix[row + 2][col + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and left
                            if (IsCellInMatrix(row - 1, col - 2, matrix))
                            {
                                if (matrix[row - 1][col - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and right
                            if (IsCellInMatrix(row - 1, col + 2, matrix))
                            {
                                if (matrix[row - 1][col + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and left
                            if (IsCellInMatrix(row + 1, col - 2, matrix))
                            {
                                if (matrix[row + 1][col - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and right
                            if (IsCellInMatrix(row + 1, col + 2, matrix))
                            {
                                if (matrix[row + 1][col + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }

                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerousKnightRow][mostDangerousKnightCol] = '0';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        public static bool IsCellInMatrix(int row, int col, char[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}

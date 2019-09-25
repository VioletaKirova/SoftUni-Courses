using System;
using System.Linq;

namespace _01_MatrixOfPalindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string[,] matrix = new string[input[0],input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char[] palindrome = new char[3]
                        {
                            alphabet[row],
                            alphabet[row + col],
                            alphabet[row]
                        };

                    matrix[row, col] = string.Join("", palindrome);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

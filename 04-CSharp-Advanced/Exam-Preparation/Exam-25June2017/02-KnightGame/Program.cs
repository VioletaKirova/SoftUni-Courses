using System;

namespace _02_KnightGame
{
    // 40/100

    class Program
    {
        static char[][] jaggedArray;
        static int deadKnights;

        static void Main(string[] args)
        {
            int rowColLen = int.Parse(Console.ReadLine());

            jaggedArray = new char[rowColLen][];

            deadKnights = 0;

            for (int row = 0; row < rowColLen; row++)
            {
                jaggedArray[row] = new char[rowColLen];

                string input = Console.ReadLine();

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (input[col] == 'K' || input[col] == '0')
                    {
                        jaggedArray[row][col] = input[col];
                    }
                }
            }

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    if (jaggedArray[row][col] == 'K')
                    {
                        MoveKnight(row, col);
                    }
                }
            }

            Console.WriteLine(deadKnights);
        }

        private static void MoveKnight(int row, int col)
        {
            if (IsInside(row - 1, col - 2))
            {
                if (jaggedArray[row - 1][col - 2] == 'K')
                {
                    jaggedArray[row - 1][col - 2] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row - 1, col + 2))
            {
                if (jaggedArray[row - 1][col + 2] == 'K')
                {
                    jaggedArray[row - 1][col + 2] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row + 1, col - 2))
            {
                if (jaggedArray[row + 1][col - 2] == 'K')
                {
                    jaggedArray[row + 1][col - 2] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row + 1, col + 2))
            {
                if (jaggedArray[row + 1][col + 2] == 'K')
                {
                    jaggedArray[row + 1][col + 2] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row - 2, col - 1))
            {
                if (jaggedArray[row - 2][col - 1] == 'K')
                {
                    jaggedArray[row - 2][col - 1] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row - 2, col + 1))
            {
                if (jaggedArray[row - 2][col + 1] == 'K')
                {
                    jaggedArray[row - 2][col + 1] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row + 2, col - 1))
            {
                if (jaggedArray[row + 2][col - 1] == 'K')
                {
                    jaggedArray[row + 2][col - 1] = '0';
                    deadKnights++;
                }
            }

            if (IsInside(row + 2, col + 1))
            {
                if (jaggedArray[row + 2][col + 1] == 'K')
                {
                    jaggedArray[row + 2][col + 1] = '0';
                    deadKnights++;
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < jaggedArray.Length && col >= 0 && col < jaggedArray[row].Length;
        }
    }
}

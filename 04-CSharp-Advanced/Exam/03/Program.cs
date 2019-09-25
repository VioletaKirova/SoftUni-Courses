using System;
using System.Linq;

namespace _03
{
    class Program
    {
        static char[][] jaggedArray;

        static int totalCoals;
        static int collectedCoals;

        static int minerRow;  
        static int minerCol;

        static bool gameOver = false;
        static bool noMoreCoals = false;

        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            jaggedArray = new char[rowsCols][];

            totalCoals = 0;
            collectedCoals = 0;

            minerRow = -1;
            minerCol = -1;

            GetJaggedArray(rowsCols);

            for (int i = 0; i < commands.Length; i++)
            {
                string currentCommand = commands[i];

                if (currentCommand == "left")
                {
                    MoveMiner(0, -1);
                }
                else if (currentCommand == "right")
                {
                    MoveMiner(0, +1);

                }
                else if (currentCommand == "up")
                {
                    MoveMiner(-1, 0);

                }
                else if (currentCommand == "down")
                {
                    MoveMiner(+1, 0);

                }

                if (gameOver)
                {
                    Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
                    break;
                }
                else if (noMoreCoals)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    break;
                }
                else if (i == commands.Length - 1)
                {
                    Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({minerRow}, {minerCol})");
                }
            }
        }

        private static void MoveMiner(int row, int col)
        {
            int targetRow = minerRow + row;
            int targetCol = minerCol + col;

            if (IsInside(targetRow, targetCol))
            {
                if (jaggedArray[targetRow][targetCol] == 'e')
                {
                    minerRow = targetRow;
                    minerCol = targetCol;

                    gameOver = true;
                }
                else if (jaggedArray[targetRow][targetCol] == 'c')
                {
                    collectedCoals++;
                    jaggedArray[targetRow][targetCol] = '*';

                    minerRow = targetRow;
                    minerCol = targetCol;

                    if (collectedCoals == totalCoals)
                    {
                        noMoreCoals = true;
                    }
                }
                else
                {
                    minerRow = targetRow;
                    minerCol = targetCol;
                }
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 &&
                row < jaggedArray.Length &&
                col >= 0 &&
                col < jaggedArray[row].Length;
        }

        private static void GetJaggedArray(int rowsCols)
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new char[rowsCols];

                char[] imput = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    jaggedArray[row][col] = imput[col];

                    if (jaggedArray[row][col] == 'c')
                    {
                        totalCoals++;
                    }
                    else if (jaggedArray[row][col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                }
            }
        }
    }
}

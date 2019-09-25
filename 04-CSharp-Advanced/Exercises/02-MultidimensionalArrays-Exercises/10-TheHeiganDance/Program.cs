using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_TheHeiganDance
{
    // 10/100

    class Program
    {
        static int[][] matrix;
        static int playerRow;
        static int playerCol;

        static void Main(string[] args)
        {
            matrix = new int[15][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[15];
            }

            playerRow = 7;
            playerCol = 7;

            double playerPoints = 18500;
            double heiganPoints = 3000000;

            double playerDamage = double.Parse(Console.ReadLine());

            bool activeCloudSpell = false;

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string spell = input[0];
                int targetRow = int.Parse(input[1]);
                int targetCol = int.Parse(input[2]);

                List<string> damagedCells = new List<string>(9);

                for (int row = targetRow - 1; row <= targetRow + 1; row++)
                {
                    for (int col = targetCol - 1; col <= targetCol + 1; col++)
                    {
                        if (IsInside(row, col))
                        {
                            AddDamagetCell(row, col, damagedCells);
                        }
                    }
                }

                heiganPoints -= playerDamage;

                if (heiganPoints > 0)
                {
                    if (!CheckForDamagedCell(damagedCells, playerRow - 1, playerCol))
                    {
                        if (IsInside(playerRow - 1, playerCol))
                        {
                            playerRow--;
                        }
                    }
                    else if (!CheckForDamagedCell(damagedCells, playerRow, playerCol + 1))
                    {
                        if (IsInside(playerRow, playerCol + 1))
                        {
                            playerCol++;
                        }
                    }
                    else if (!CheckForDamagedCell(damagedCells, playerRow + 1, playerCol))
                    {
                        if (IsInside(playerRow + 1, playerCol))
                        {
                            playerRow++;
                        }
                    }
                    else if (!CheckForDamagedCell(damagedCells, playerRow, playerCol - 1))
                    {
                        if (IsInside(playerRow, playerCol - 1))
                        {
                            playerCol--;
                        }
                    }
                    else
                    {
                        if (activeCloudSpell)
                        {
                            playerPoints -= 3500;
                        }

                        if (spell == "Cloud")
                        {
                            playerPoints -= 3500;

                            activeCloudSpell = true;
                        }
                        else
                        {
                            playerPoints -= 6000;

                            activeCloudSpell = false;
                        }
                    }
                }
              
                if (heiganPoints > 0 && playerPoints <= 0)
                {
                    Console.WriteLine($"Heigan: {heiganPoints:f2}");

                    if (spell == "Cloud")
                    {
                        Console.WriteLine($"Player: Killed by Plague Cloud");
                    }
                    else
                    {
                        Console.WriteLine($"Player: Killed by {spell}");
                    }

                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                    break;
                }
                else if (heiganPoints <= 0 && playerPoints > 0)
                {
                    Console.WriteLine($"Heigan: Defeated!");
                    Console.WriteLine($"Player: {playerPoints}");
                    Console.WriteLine($"Final position: {playerRow}, {playerCol}");

                    break;
                }
            }
        }

        private static bool CheckForDamagedCell(List<string> damagedCells, int row, int col)
        {
            return damagedCells.Contains($"{row}{col}");
        }

        private static void AddDamagetCell(int damagedRow, int damagedCol, List<string> damagedCells)
        {
            damagedCells.Add($"{damagedRow}{damagedCol}");
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}

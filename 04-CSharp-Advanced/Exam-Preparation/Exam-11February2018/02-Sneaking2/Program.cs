using System;
using System.Collections.Generic;

namespace _02_Sneaking
{
    // 50/100

    class Program
    {
        static string[][] jaggedArray;

        static int samRow;
        static int samCol;

        static int nikoladzeCol;
        static int nikoladzeRow;

        static List<int> enemiesRows;

        static bool someoneIsKilled;

        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            jaggedArray = new string[rows][];

            enemiesRows = new List<int>();

            FillJaggedArray(rows, enemiesRows);

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemies();

                char currentMove = directions[i];

                if (currentMove == 'U')
                {
                    MoveUp();
                }
                else if (currentMove == 'D')
                {
                    MoveDown();
                }
                else if (currentMove == 'L')
                {
                    MoveLeft();
                }
                else if (currentMove == 'R')
                {
                    MoveRight();
                }

                if (someoneIsKilled)
                {
                    break;
                }
            }
        }

        private static void MoveRight()
        {
            int targetCol = samCol + 1;

            jaggedArray[samRow][samCol] = ".";
            jaggedArray[samRow][targetCol] = "S";

            samCol = targetCol;
        }

        private static void MoveLeft()
        {
            int targetCol = samCol - 1;

            jaggedArray[samRow][samCol] = ".";
            jaggedArray[samRow][targetCol] = "S";

            samCol = targetCol;
        }

        private static void MoveDown()
        {
            int targetRow = samRow + 1;

            CheckUpDownRow(targetRow);

        }

        private static void MoveUp()
        {
            int targetRow = samRow - 1;

            CheckUpDownRow(targetRow);
        }

        private static void CheckUpDownRow(int targetRow)
        {
            string targetRowStr = string.Join("", jaggedArray[targetRow]);

            if (jaggedArray[targetRow][samCol] == "b" || jaggedArray[targetRow][samCol] == "d")
            {
                jaggedArray[samRow][samCol] = ".";
                jaggedArray[targetRow][samCol] = "S";

                samRow = targetRow;
            }
            else if (targetRowStr.Contains("b"))
            {
                int indexOfEnemy = targetRowStr.IndexOf("b");

                if (indexOfEnemy < samCol)
                {
                    SamKilledByEnemy(targetRow);
                }
            }
            else if (targetRowStr.Contains("d"))
            {
                int indexOfEnemy = targetRowStr.IndexOf("d");

                if (indexOfEnemy > samCol)
                {
                    SamKilledByEnemy(targetRow);
                }
            }
            else if (targetRow == nikoladzeRow)
            {
                SamKillsNikoladze(targetRow);
            }
            else
            {
                jaggedArray[samRow][samCol] = ".";
                jaggedArray[targetRow][samCol] = "S";

                samRow = targetRow;
            }
        }

        private static void SamKillsNikoladze(int targetRow)
        {
            jaggedArray[nikoladzeRow][nikoladzeCol] = "X";

            jaggedArray[samRow][samCol] = ".";
            jaggedArray[targetRow][samCol] = "S";

            Console.WriteLine("Nikoladze killed!");

            PrintJaggedArray();

            someoneIsKilled = true;
        }

        private static void SamKilledByEnemy(int targetRow)
        {
            jaggedArray[samRow][samCol] = ".";
            jaggedArray[targetRow][samCol] = "X";

            samRow = targetRow;

            Console.WriteLine($"Sam died at {samRow}, {samCol}");

            PrintJaggedArray();

            someoneIsKilled = true;
        }

        private static void MoveEnemies()
        {
            for (int j = 0; j < enemiesRows.Count; j++)
            {
                int enemyRowIndex = enemiesRows[j];
                string enemyRow = string.Join("", jaggedArray[enemyRowIndex]);

                int enemyColIndex = -1;

                int targetCol = -1;

                if (enemyRow.Contains("b"))
                {
                    enemyColIndex = enemyRow.IndexOf("b");

                    if (enemyColIndex != jaggedArray[enemyRowIndex].Length - 1)
                    {
                        targetCol = enemyColIndex + 1;

                        jaggedArray[enemyRowIndex][enemyColIndex] = ".";
                        jaggedArray[enemyRowIndex][targetCol] = "b";
                    }
                    else
                    {
                        jaggedArray[enemyRowIndex][enemyColIndex] = "d";

                        CheckForSam(enemyRowIndex);
                    }

                }
                else if (enemyRow.Contains("d"))
                {
                    enemyColIndex = enemyRow.IndexOf("d");

                    if (enemyColIndex != 0)
                    {
                        targetCol = enemyColIndex - 1;

                        jaggedArray[enemyRowIndex][enemyColIndex] = ".";
                        jaggedArray[enemyRowIndex][targetCol] = "d";
                    }
                    else
                    {
                        jaggedArray[enemyRowIndex][enemyColIndex] = "b";

                        CheckForSam(enemyRowIndex);
                    }
                }
            }
        }

        private static void CheckForSam(int enemyRowIndex)
        {
            if (enemyRowIndex == samRow)
            {
                jaggedArray[samRow][samCol] = "X";

                Console.WriteLine($"Sam died at {samRow}, {samCol}");

                PrintJaggedArray();

                someoneIsKilled = true;
            }
        }

        private static void PrintJaggedArray()
        {
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                Console.WriteLine(string.Join("", jaggedArray[row]));
            }
        }

        private static void FillJaggedArray(int rows, List<int> enemiesRows)
        {
            for (int row = 0; row < rows; row++)
            {
                string currentRow = Console.ReadLine();
                jaggedArray[row] = new string[currentRow.Length];

                for (int col = 0; col < currentRow.Length; col++)
                {
                    jaggedArray[row][col] = currentRow[col].ToString();

                    if (jaggedArray[row][col] == "S")
                    {
                        samRow = row;
                        samCol = col;
                    }
                    else if (jaggedArray[row][col] == "N")
                    {
                        nikoladzeRow = row;
                        nikoladzeCol = col;
                    }
                    else if (jaggedArray[row][col] == "b" || jaggedArray[row][col] == "d")
                    {
                        enemiesRows.Add(row);
                    }
                }
            }
        }
    }
}

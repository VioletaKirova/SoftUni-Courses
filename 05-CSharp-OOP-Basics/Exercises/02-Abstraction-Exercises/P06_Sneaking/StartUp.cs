using System;

namespace P06_Sneaking
{
    class StartUp
    {
        static char[][] room;

        static int samRow;
        static int samCol;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            room = new char[rows][];
            FillRoom(rows);

            var moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                MoveEnemies();

                // Check for enemies on Sam's row
                int[] enemyCoordinates = GetEnemyCoordinates();

                int enemyRow = enemyCoordinates[0];
                int enemyCol = enemyCoordinates[1];

                if (samCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == samRow)
                {
                    SamDies();
                }
                else if (enemyCol < samCol && room[enemyRow][enemyCol] == 'b' && enemyRow == samRow)
                {
                    SamDies();
                }

                MoveSam(moves, i);

                // Check for Nikoladze on Sam's row
                enemyCoordinates = GetEnemyCoordinates();

                enemyRow = enemyCoordinates[0];
                enemyCol = enemyCoordinates[1];

                if (room[enemyRow][enemyCol] == 'N' && samRow == enemyRow)
                {
                    room[enemyRow][enemyCol] = 'X';

                    Console.WriteLine("Nikoladze killed!");

                    PrintRoom();
                }
            }
        }

        private static void MoveSam(char[] moves, int i)
        {
            room[samRow][samCol] = '.';

            switch (moves[i])
            {
                case 'U':
                    samRow--;
                    break;
                case 'D':
                    samRow++;
                    break;
                case 'L':
                    samCol--;
                    break;
                case 'R':
                    samCol++;
                    break;
                default:
                    break;
            }

            room[samRow][samCol] = 'S';
        }

        private static void SamDies()
        {
            room[samRow][samCol] = 'X';

            Console.WriteLine($"Sam died at {samRow}, {samCol}");

            PrintRoom();
        }

        private static int[] GetEnemyCoordinates()
        {
            int[] enemyCoordinates = new int[2];

            for (int col = 0; col < room[samRow].Length; col++)
            {
                if (room[samRow][col] != '.' && room[samRow][col] != 'S')
                {
                    enemyCoordinates[0] = samRow;
                    enemyCoordinates[1] = col;
                }
            }
            return enemyCoordinates;
        }

        private static void PrintRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }

            Environment.Exit(0);
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FillRoom(int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                var input = Console.ReadLine().ToCharArray();

                room[row] = new char[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];

                    GetSamCoordinates(row, col);
                }
            }
        }

        private static void GetSamCoordinates(int row, int col)
        {
            if (room[row][col] == 'S')
            {
                samRow = row;
                samCol = col;
            }
        }
    }
}

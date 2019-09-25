using System;
using System.Linq;

namespace _02_ParkingFeud
{
    // Unfinished

    class Program
    {
        static void Main(string[] args)
        {
            int[] parkingRowsCols = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = parkingRowsCols[0] * 2 - 1;
            int cols = parkingRowsCols[1] + 2;

            int[][] jaggedArray = new int[rows][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new int[cols];
            }

            int samEntranceRow = int.Parse(Console.ReadLine());

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (true)
            {
                string samParkingSpot = input[0];

                int samParkingRow = int.Parse(samParkingSpot[1].ToString());
                char samParkingChar = samParkingSpot[0];

                int oponentEntranceRow = 0;
                int oponentParkingRow = 0;
                char oponentParkingCol = ' ';

                bool parkingFeud = false;
                bool samParked = false;

                for (int i = 1; i < input.Length; i++)
                {
                    if (input[i][0] == samParkingChar && int.Parse(input[i][1].ToString()) == samParkingRow)
                    {
                        parkingFeud = true;

                        oponentEntranceRow = FindEntrance(i + 1);

                        oponentParkingRow = samParkingRow;
                        oponentParkingCol = samParkingChar;

                        if (parkingFeud)
                        {
                            break;
                        }
                    }
                }

                if (!parkingFeud)
                {
                    samParkingRow = FindParkingRow(samParkingRow);
                    int samParkingCol = FindParkingCol(samParkingChar);
                    samEntranceRow = FindEntrance(samEntranceRow);

                    int samSquaresCount = 0;
                    int switchSides = 0;

                    for (int row = samEntranceRow; row < samParkingRow; row += 2)
                    {
                        if (switchSides % 2 == 0)
                        {
                            for (int col = 0; col < jaggedArray[row].Length; col++)
                            {
                                samSquaresCount++;

                                if ((row - 1 == samParkingRow && col == samParkingCol) ||
                                    (row + 1 == samParkingRow && col == samParkingCol))
                                {
                                    samParked = true;
                                }
                            }

                            switchSides = 1;
                        }
                        else
                        {
                            for (int col = jaggedArray[row].Length - 1; col >= 0; col--)
                            {
                                samSquaresCount++;

                                if ((row - 1 == samParkingRow && col == samParkingCol) ||
                                    (row + 1 == samParkingRow && col == samParkingCol))
                                {
                                    samParked = true;
                                }
                            }

                            switchSides = 0;
                        }

                        if (samParked)
                        {
                            Console.WriteLine($"Parked successfully at {samParkingSpot}.");
                            Console.WriteLine($"Total Distance Passed: {samSquaresCount}");

                            break;
                        }

                        samSquaresCount++;
                    }
                }

                if (!samParked)
                {
                    input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                }
                else
                {
                    break;
                }
                
            }
        }

        private static int FindParkingCol(char parkingChar)
        {
            int parkingCol = 0;

            switch (parkingChar)
            {
                case 'A':
                    parkingCol = 1;
                    break;
                case 'B':
                    parkingCol = 2;
                    break;
                case 'C':
                    parkingCol = 3;
                    break;
                case 'D':
                    parkingCol = 4;
                    break;
                case 'E':
                    parkingCol = 5;
                    break;
                case 'F':
                    parkingCol = 6;
                    break;
                case 'G':
                    parkingCol = 7;
                    break;
                case 'H':
                    parkingCol = 8;
                    break;
                case 'I':
                    parkingCol = 9;
                    break;
                case 'J':
                    parkingCol = 10;
                    break;
            }

            return parkingCol;
        }

        private static int FindParkingRow(int parkingRow)
        {
            switch (parkingRow)
            {
                case 1:
                    parkingRow = 0;
                    break;
                case 2:
                    parkingRow = 2;
                    break;
                case 3:
                    parkingRow = 5;
                    break;
                case 4:
                    parkingRow = 7;
                    break;
                case 5:
                    parkingRow = 9;
                    break;
                case 6:
                    parkingRow = 11;
                    break;
                case 7:
                    parkingRow = 13;
                    break;
                case 8:
                    parkingRow = 15;
                    break;
                case 9:
                    parkingRow = 17;
                    break;
                case 10:
                    parkingRow = 19;
                    break;
            }

            return parkingRow;
        }

        private static int FindEntrance(int findEntranceRow)
        {
            switch (findEntranceRow)
            {
                case 1:
                    findEntranceRow = 1;
                    break;
                case 2:
                    findEntranceRow = 3;
                    break;
                case 3:
                    findEntranceRow = 5;
                    break;
                case 4:
                    findEntranceRow = 7;
                    break;
                case 5:
                    findEntranceRow = 9;
                    break;
                case 6:
                    findEntranceRow = 11;
                    break;
                case 7:
                    findEntranceRow = 13;
                    break;
                case 8:
                    findEntranceRow = 15;
                    break;
                case 9:
                    findEntranceRow = 17;
                    break;
                case 10:
                    findEntranceRow = 19;
                    break;
            }

            return findEntranceRow;
        }
    }
}

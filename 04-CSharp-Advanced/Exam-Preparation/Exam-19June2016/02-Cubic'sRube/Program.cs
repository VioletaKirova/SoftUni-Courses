using System;
using System.Linq;

namespace _02_Cubic_sRube
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,,] cube = new int[n, n, n]; 

            int totalCellsInCube = n * n * n;
            int filledCells = 0;
            long totalSum = 0;

            string input = Console.ReadLine();

            while (input != "Analyze")
            {
                int[] inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = inputArgs[0];
                int col = inputArgs[1];
                int height = inputArgs[2];
                int value = inputArgs[3];

                if (IsInside(row, col, height, value, cube))
                {
                    cube[row, col, height] = value;
                    filledCells++;
                    totalSum += value;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine(totalSum);
            Console.WriteLine(totalCellsInCube - filledCells);
        }

        private static bool IsInside(int row, int col, int height, int value, int[,,] cube)
        {
            return row >= 0 && 
                row < cube.GetLength(0) && 
                col >= 0 && 
                col < cube.GetLength(1) && 
                height >= 0 && 
                height < cube.GetLength(2) &&
                value != 0;
        }
    }
}

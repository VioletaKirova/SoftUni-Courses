using System;

namespace _04_PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            long height = long.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[height][];

            for (int row = 0; row < jaggedArray.Length; row++)
            {
                jaggedArray[row] = new long[row + 1];

                jaggedArray[row][0] = 1;

                if (row > 0)
                {
                    jaggedArray[row][jaggedArray[row].Length - 1] = 1;
                }

                if (row > 1)
                {
                    for (int col = 1; col < jaggedArray[row].Length - 1; col++)
                    {
                        long rightElement = jaggedArray[row - 1][col];
                        long leftElement = jaggedArray[row - 1][col - 1];
                        long currentElement = rightElement + leftElement;
                        jaggedArray[row][col] = currentElement;
                    }
                }
            }

            foreach (var arr in jaggedArray)
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}

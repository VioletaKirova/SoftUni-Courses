using System;

namespace _01_RhombusOfStars
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int rhombusSize = GetRhombusSize();

            PrintRhombus(rhombusSize);
        }

        private static void PrintRhombus(int rhombusSize)
        {
            PrintUpperPart(rhombusSize);
            PrintLowerPart(rhombusSize);
        }

        private static void PrintLowerPart(int rhombusSize)
        {
            for (int i = rhombusSize - 1; i >= 1; i--)
            {
                int spaces = rhombusSize - i;
                int stars = i;

                string row = FormCurrentRow(spaces, stars);
                PrintRow(row);
            }
        }

        private static void PrintUpperPart(int rhombusSize)
        {
            for (int i = 1; i <= rhombusSize; i++)
            {
                int spaces = rhombusSize - i;
                int stars = i;

                string row = FormCurrentRow(spaces, stars);
                PrintRow(row);
            }
        }

        public static string FormCurrentRow(int spaces, int stars)
        {
            string spacesStr = new string(' ', spaces);
            string starsStr = "";

            for (int i = 0; i < stars; i++)
            {
                if (i == stars - 1)
                {
                    spacesStr += "*";

                }
                else
                {
                    spacesStr += "* ";
                }
            }

            return spacesStr + starsStr;
        }

        private static void PrintRow(string row)
        {
            Console.WriteLine(row);
        }

        private static int GetRhombusSize()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}

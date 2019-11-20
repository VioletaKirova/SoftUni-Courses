using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_CompareCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] secondArr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            int shorterArrLength = Math.Min(firstArr.Length, secondArr.Length);
            bool differance = false;

            for (int i = 0; i < shorterArrLength; i++)
            {
                if (firstArr[i] != secondArr[i])
                {
                    differance = true;
                    break;
                }
            }

            if (differance)
            {
                if (firstArr[0] < secondArr[0])
                {
                    Console.WriteLine(string.Join("", firstArr));
                    Console.WriteLine(string.Join("", secondArr));
                }
                else
                {
                    Console.WriteLine(string.Join("", secondArr));
                    Console.WriteLine(string.Join("", firstArr));
                }
            }

            if (!differance)
            {
                if (firstArr.Length <= secondArr.Length)
                {
                    Console.WriteLine(string.Join("", firstArr));
                    Console.WriteLine(string.Join("", secondArr));
                }
                else
                {
                    Console.WriteLine(string.Join("", secondArr));
                    Console.WriteLine(string.Join("", firstArr));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ArrayStatistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int minValue = numArr[0];
            int maxValue = numArr[0];
            int sum = 0;
            double average = 0;

            for (int i = 0; i < numArr.Length; i++)
            {
                if (minValue > numArr[i])
                {
                    minValue = numArr[i];
                }

                if (maxValue < numArr[i])
                {
                    maxValue = numArr[i];
                }

                sum += numArr[i];
            }

            average = (double)sum / numArr.Length;

            Console.WriteLine($"Min = {minValue}");
            Console.WriteLine($"Max = {maxValue}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
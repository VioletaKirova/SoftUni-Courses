using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_RotateAndSum2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            int[] tempArr = new int[inputArr.Length - 1];
            int[] newArr = new int[inputArr.Length];
            int[] sum = new int[inputArr.Length];

            for (int i = 0; i < rotations; i++)
            {
                for (int j = 0; j < tempArr.Length; j++)
                {
                    tempArr[j] = inputArr[j];
                }

                newArr[0] = inputArr[inputArr.Length - 1];

                for (int j = 0; j < tempArr.Length; j++)
                {
                    newArr[j + 1] = tempArr[j];
                }

                inputArr = newArr;

                for (int j = 0; j < inputArr.Length; j++)
                {
                    sum[j] += newArr[j];
                }
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

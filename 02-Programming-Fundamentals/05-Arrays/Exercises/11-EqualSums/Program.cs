using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rightSum = 0;
            int leftSum = 0;

            if (arr.Length == 1)
            {
                Console.WriteLine("0");
            }
            else
            {
                for (int i = 1; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        rightSum += arr[j];
                    }

                    for (int k = i + 1; k < arr.Length; k++)
                    {
                        leftSum += arr[k];
                    }

                    if (rightSum == leftSum)
                    {
                        Console.WriteLine($"{i}");
                    }
                    else if (i == arr.Length - 2)
                    {
                        Console.WriteLine("no");
                    }
                }

            }  
        }
    }
}

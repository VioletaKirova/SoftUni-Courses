using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SearchForANumber
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> outputNums = new List<int>();

            for (int i = 0; i < arr[0]; i++)
            {
                outputNums.Add(nums[i]);
            }

            for (int i = 0; i < arr[1]; i++)
            {
                outputNums.RemoveAt(0);
            }

            //for (int i = 0; i < outputNums.Count; i++)
            //{
            //    if (arr[2] == outputNums[i])
            //    {
            //        Console.WriteLine("YES!");
            //        break;
            //    }
            //    else if (i == outputNums.Count - 1)
            //    {
            //        Console.WriteLine("NO!");
            //    }
            //}

            if (outputNums.Contains(arr[2]))
            {
                Console.WriteLine("YES!");
            }
            else
            {
                Console.WriteLine("NO!");
            }
        }
    }
}
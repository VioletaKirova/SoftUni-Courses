using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_JumpAround
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = 0;

            for (int i = 0; i < arr.Length;)
            {
                int step = arr[i];
                sum += arr[i];

                if (i + step < arr.Length)
                {
                    i = i + step;
                }
                else if (i - step >= 0)
                {
                    i = i - step;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
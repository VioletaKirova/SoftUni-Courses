using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FoldAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] firstQuarter = new int[arr.Length / 4];
            int[] lastQuarter= new int[arr.Length / 4];

            for (int i = 0; i <= firstQuarter.Length - 1; i++)
            {
                firstQuarter[i] = arr[i];
            }

            Array.Reverse(firstQuarter);

            for (int i = 0; i <= firstQuarter.Length - 1; i++)
            {
                lastQuarter[i] = arr[arr.Length - 1 - i];
            }

            int[] combinedQuarters = firstQuarter.Concat(lastQuarter).ToArray();
            int[] sum = new int[combinedQuarters.Length];
            int[] cuttedInputArr = new int[combinedQuarters.Length];

            for (int i = 0; i < cuttedInputArr.Length; i++)
            {
                cuttedInputArr[i] = arr[i + firstQuarter.Length];
            }

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = cuttedInputArr[i] + combinedQuarters[i];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}

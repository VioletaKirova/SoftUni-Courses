using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int length = 1;
            int largestFrequency = 0;
            int mostFrequentNum = arr[0];

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[i] == arr[i + j])
                    {
                        length++;
                    }

                    if (length > largestFrequency)
                    {
                        mostFrequentNum = arr[i];
                        largestFrequency = length;
                    }
                }

                length = 1;
            }

            Console.WriteLine(mostFrequentNum);
        }
    }
}

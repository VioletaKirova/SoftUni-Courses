using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int lengthOfLoop = Math.Max(firstArr.Length, secondArr.Length);

            for (int i = 0; i < lengthOfLoop; i++)
            {
                int firstValue = firstArr[i % firstArr.Length];
                int secondValue = secondArr[i % secondArr.Length];
                Console.Write("{0} ", firstValue + secondValue);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_TripleSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            int[] array = input.Split(' ').Select(str => int.Parse(str)).ToArray();

            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                for (int y = i + 1; y < array.Length; y++)
                {
                    for (int z = 0; z < array.Length; z++)
                    {
                        if (array[i] + array[y] == array[z])
                        {
                            Console.WriteLine($"{array[i]} + {array[y]} == {array[z]}");
                            isFound = true;
                            break;
                        }
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}

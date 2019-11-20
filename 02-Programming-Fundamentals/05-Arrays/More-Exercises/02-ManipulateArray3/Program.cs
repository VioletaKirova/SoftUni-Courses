using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ManipulateArray3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ').ToArray();

                if (command[0] == "Reverse")
                {
                    arr = ToReverse(arr);
                }
                else if (command[0] == "Distinct")
                {
                    arr = ToDistinct(arr);
                }
                else if (command[0] == "Replace")
                {
                    arr = ToReplace(arr, command);
                }
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        static string[] ToReverse(string[] arr)
        {
            arr = arr.Reverse().ToArray();
            return arr;
        }

        static string[] ToDistinct(string[] arr)
        {
            arr = arr.Distinct().ToArray();
            return arr;
        }

        static string[] ToReplace(string[] arr, string[] command)
        {
            int index = int.Parse(command[1]);
            arr[index] = command[2];
            return arr;
        }
    }
}
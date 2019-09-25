using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ManipulateArray2
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
                    arr = arr.Reverse().ToArray();
                }
                else if (command[0] == "Distinct")
                {
                    arr = arr.Distinct().ToArray();
                }
                else if (command[0] == "Replace")
                {
                    int index = int.Parse(command[1]);
                    arr[index] = command[2];
                }
            }

            string output = "";

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null)
                {
                    output += $"{arr[i]}, ";
                }
            }

            output = output.Remove(output.Length - 2);
            Console.WriteLine(output);
        }
    }
}
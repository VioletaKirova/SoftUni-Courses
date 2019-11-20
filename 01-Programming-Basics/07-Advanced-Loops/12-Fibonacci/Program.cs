using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int firstNum = 1;
            int secondNum = 1;
            int currentNum = 1;

            for (int i = 1; i < n; i++)
            {
                currentNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = currentNum;
            }

            Console.WriteLine(currentNum);
        }
    }
}

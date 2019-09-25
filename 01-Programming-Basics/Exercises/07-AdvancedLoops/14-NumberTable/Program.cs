using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_NumberTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n; j++)
                {
                    Console.Write(j + " ");
                }

                for (int j = n - 1; j > n - i; j--)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

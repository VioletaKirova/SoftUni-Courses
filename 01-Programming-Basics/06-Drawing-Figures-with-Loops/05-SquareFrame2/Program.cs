﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_SquareFrame2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.Write("+ ");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+ ");

            for (int i = 0; i < n - 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == 0 || j == n - 1)
                        Console.Write("| ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }

            Console.Write("+ ");
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("- ");
            }
            Console.WriteLine("+ ");
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_NumberChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var n = int.Parse(Console.ReadLine());
                Console.WriteLine("It is a number.");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input!"); ;
            }
        }
    }
}

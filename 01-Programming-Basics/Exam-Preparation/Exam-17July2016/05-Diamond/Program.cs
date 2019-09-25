using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Diamond
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //Top Part
            for (int i = n; i >= 1; i--)
            {
                //First Line
                if (i == n)
                {
                Console.Write(new string('.', i));
                Console.Write(new string('*', n * 3));
                Console.WriteLine(new string('.', i));
                }
                else
                {
                    Console.Write(new string('.', i));
                    Console.Write("*");
                    Console.Write(new string('.', (n * 5 - (i * 2 + 2))));
                    Console.Write("*");
                    Console.WriteLine(new string('.', i));
                }
            }

            //Middle Line
            Console.WriteLine(new string('*', n * 5));

            //Bottom Part
            for (int i = 1; i <= (n * 2 + 1); i++)
            {
                if (i == n * 2 + 1)
                {
                    Console.Write(new string('.', i));
                    Console.Write("*");
                    Console.Write(new string('*', (n * 5 - (i * 2 + 2))));
                    Console.Write("*");
                    Console.WriteLine(new string('.', i));
                }
                else
                {
                    Console.Write(new string('.', i));
                    Console.Write("*");
                    Console.Write(new string('.', (n * 5 - (i * 2 + 2))));
                    Console.Write("*");
                    Console.WriteLine(new string('.', i));
                }
            }
        }
    }
}

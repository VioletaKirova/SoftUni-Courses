using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Snowflake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Console.WriteLine($"{new string('.', i)}" +
                    $"*{new string('*', n - i)}" +
                    $"*{new string('*', n - i)}" +
                    $"*{new string('.', i)}");
                }
                else
                {
                    Console.WriteLine($"{new string('.', i)}" +
                        $"*{new string('.', n - i)}" +
                        $"*{new string('.', n - i)}" +
                        $"*{new string('.', i)}");
                }
            }

            //Middle Row:
            Console.WriteLine(new string ('*', n * 2 + 3));

            for (int i = n - 1; i >= 0; i--)
            {
                if (i == n - 1)
                {
                    Console.WriteLine($"{new string('.', i)}" +
                    $"*{new string('*', n - i)}" +
                    $"*{new string('*', n - i)}" +
                    $"*{new string('.', i)}");
                }
                else
                {
                Console.WriteLine($"{new string('.', i)}" +
                    $"*{new string('.', n - i)}" +
                    $"*{new string('.', n - i)}" +
                    $"*{new string('.', i)}");
                }
            }
        }
    }
}

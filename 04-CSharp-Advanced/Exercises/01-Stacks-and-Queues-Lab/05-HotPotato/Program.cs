using System;
using System.Collections.Generic;

namespace _05_HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(' ');
            int tosses = int.Parse(Console.ReadLine());

            Queue<string> queue = new Queue<string>(kids);

            while (queue.Count > 1)
            {
                for (int i = 1; i <= tosses; i++)
                {
                    if (i == tosses)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        queue.Enqueue(queue.Dequeue());
                    }
                }
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}

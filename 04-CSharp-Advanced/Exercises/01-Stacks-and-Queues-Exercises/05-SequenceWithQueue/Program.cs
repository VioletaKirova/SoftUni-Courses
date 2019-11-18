using System;
using System.Collections.Generic;

namespace _05_SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            Queue<long> allNumbers = new Queue<long>();
            allNumbers.Enqueue(n);;

            for (int i = 0; i < 49; i+=3)
            {
                long number = 0;

                if (i == 0)
                {
                    number = n;
                }
                else
                {
                    long[] queueNumbers = allNumbers.ToArray();
                    number = queueNumbers[queueNumbers.Length - 3];
                }

                long firstNum = number + 1;
                allNumbers.Enqueue(firstNum);

                long secondNum = 2 * number + 1;
                allNumbers.Enqueue(secondNum);

                long thirdNum = number + 2;
                allNumbers.Enqueue(thirdNum);
            }

            Console.WriteLine(string.Join(' ', allNumbers.ToArray()));
        }
    }
}

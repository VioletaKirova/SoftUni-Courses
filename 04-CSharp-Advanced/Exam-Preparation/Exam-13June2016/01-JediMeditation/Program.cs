using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_JediMeditation
{
    // 90/100 -> Time limit

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> toshkoSlav = new Queue<string>();

            List<string> ordered = new List<string>();

            int n = int.Parse(Console.ReadLine());

            bool masterYodaAppears = false;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    char symbol = (char)input[j][0];

                    switch (symbol)
                    {
                        case 'm':
                            masters.Enqueue(input[j]);
                            break;
                        case 'k':
                            knights.Enqueue(input[j]);
                            break;
                        case 'p':
                            padawans.Enqueue(input[j]);
                            break;
                        case 't':
                        case 's':
                            toshkoSlav.Enqueue(input[j]);
                            break;
                        case 'y':
                            masterYodaAppears = true;
                            break;
                    }
                }
            }

            if (masterYodaAppears)
            {
                FillOrderedList(masters, ordered);
                FillOrderedList(knights, ordered);
                FillOrderedList(toshkoSlav, ordered);
                FillOrderedList(padawans, ordered);
            }
            else
            {
                FillOrderedList(toshkoSlav, ordered);
                FillOrderedList(masters, ordered);
                FillOrderedList(knights, ordered);
                FillOrderedList(padawans, ordered);
            }

            Print(ordered);
        }

        private static void Print(List<string> ordered)
        {
            foreach (var item in ordered)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        private static void FillOrderedList(Queue<string> jedis, List<string> ordered)
        {
            if (jedis.Any())
            {
                while (jedis.Count > 0)
                {
                    ordered.Add(jedis.Dequeue());
                }
            }
        }
    }
}

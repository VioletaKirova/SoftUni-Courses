using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_JediMeditation
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> masters = new Queue<string>();
            Queue<string> knights = new Queue<string>();
            Queue<string> padawans = new Queue<string>();
            Queue<string> toshkoSlav = new Queue<string>();

            StringBuilder ordered = new StringBuilder();

            int n = int.Parse(Console.ReadLine());

            bool masterYodaAppears = false;

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
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

            Console.WriteLine(ordered);
        }

        private static void FillOrderedList(Queue<string> jedis, StringBuilder ordered)
        {
            if (jedis.Any())
            {
                while (jedis.Count > 0)
                {
                    ordered.Append(jedis.Dequeue() + " ");
                }
            }
        }
    }
}

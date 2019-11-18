using System;
using System.Collections.Generic;

namespace _05_SequenceWithQueue2
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<long> seqTemp = new Queue<long>();
            Queue<long> seqPrint = new Queue<long>();

            long n = long.Parse(Console.ReadLine());

            seqTemp.Enqueue(n);

            while (seqPrint.Count <= 49)
            {
                seqTemp.Enqueue(seqTemp.Peek() + 1);
                seqTemp.Enqueue(2 * seqTemp.Peek() + 1);
                seqTemp.Enqueue(seqTemp.Peek() + 2);

                seqPrint.Enqueue(seqTemp.Dequeue());
            }

            while (seqPrint.Count > 0)
            {
                Console.Write(seqPrint.Dequeue() + " ");
            }

            Console.WriteLine();
        }
    }
}

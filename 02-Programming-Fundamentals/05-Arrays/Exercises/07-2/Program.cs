using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sequenceLength = 1;
            int sequenceStart = inputArray[0];
            int longestSequenceLength = 1;
            int longestSequenceStart = inputArray[0];

            for (int i = 1; i < inputArray.Length; i++)
            {
                if (inputArray[i] > (inputArray[i - 1]))
                {
                    sequenceLength++;

                    if (sequenceLength > longestSequenceLength)
                    {
                        longestSequenceLength = sequenceLength;
                        longestSequenceStart = sequenceStart;
                    }
                }
                else
                {
                    sequenceStart = inputArray[i];
                    sequenceLength = 1;
                }
            }

            for (int i = longestSequenceStart; i < longestSequenceStart + longestSequenceLength; i++)
            {
                Console.Write(i + " ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_TwoNumbersSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginning = int.Parse(Console.ReadLine());
            int ending = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int count = 0;
            bool magicNumReached = false;

            int firstNum = 0;
            int secondNum = 0;

            for (int i = beginning; i >= ending; i--)
            {
                for (int h = beginning; h >= ending; h--)
                {
                    count++;

                    if (i + h == magicNumber)
                    {
                        magicNumReached = true;

                        firstNum = i;
                        secondNum = h;

                        break;
                    }
                }
                if(magicNumReached)
                {
                    break;
                }
            }

            if (magicNumReached)
            {
                Console.WriteLine($"Combination N:{count} ({firstNum} + {secondNum} = {magicNumber})");
            }
            else
            {
                Console.WriteLine($"{count} combinations - neither equals {magicNumber}");
            }
        }
    }
}

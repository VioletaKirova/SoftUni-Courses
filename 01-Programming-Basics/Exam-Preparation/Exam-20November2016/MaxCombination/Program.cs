using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            int beginning = int.Parse(Console.ReadLine());
            int ending = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            int count = 0;

            for (int i = beginning; i <= ending; i++)
            {
                for (int j = beginning; j <= ending; j++)
                {
                    count++;

                    if (count > max)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write($"<{i}-{j}>");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int currentNum = 1;

            bool reachedNum = false;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(currentNum + " ");
                    currentNum++;

                    if (currentNum > n)
                    {
                        reachedNum = true;
                        break;
                    }
                }

                Console.WriteLine();

                if (reachedNum)
                {
                    break;
                }
            }
        }
    }
}

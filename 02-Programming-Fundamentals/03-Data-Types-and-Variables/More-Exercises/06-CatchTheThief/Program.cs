using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CatchTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string numType = Console.ReadLine();
            sbyte n = sbyte.Parse(Console.ReadLine());
            long maxValue = long.MinValue;

            for (sbyte i = 0; i < n; i++)
            {
                string currentNum = Console.ReadLine();

                if (numType == "sbyte")
                {
                    if (long.Parse(currentNum) <= sbyte.MaxValue && long.Parse(currentNum) > maxValue)
                    {
                        maxValue = long.Parse(currentNum);
                    }
                }
                else if (numType == "int")
                {
                    if (long.Parse(currentNum) <= int.MaxValue && long.Parse(currentNum) > maxValue)
                    {
                        maxValue = long.Parse(currentNum);
                    }
                }
                else if (numType == "long")
                {
                    if (long.Parse(currentNum) <= long.MaxValue && long.Parse(currentNum) > maxValue)
                    {
                        maxValue = long.Parse(currentNum);
                    }
                }
            }

            Console.WriteLine(maxValue);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_ComparingFloats
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            double difference = Math.Abs(a - b);
            bool equal = false;

            if (difference < 0.000001)
            {
                equal = true;
                Console.WriteLine(equal);
            }
            else
            {
                Console.WriteLine(equal);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_IntegerToHexAndBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string hex = Convert.ToString(n, 16).ToUpper();
            Console.WriteLine(hex);
            string bi = Convert.ToString(n, 2);
            Console.WriteLine(bi);
        }
    }
}

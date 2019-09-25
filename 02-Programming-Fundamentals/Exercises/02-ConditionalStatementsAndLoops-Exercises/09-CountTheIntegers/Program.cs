using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 0;

            for (int i = 0; ; i++)
            {
                try
                {
                    var data = int.Parse(Console.ReadLine());
                    count++;
                }
                catch (Exception)
                {
                    Console.WriteLine(count);
                    break;
                }
            }
        }
    }
}

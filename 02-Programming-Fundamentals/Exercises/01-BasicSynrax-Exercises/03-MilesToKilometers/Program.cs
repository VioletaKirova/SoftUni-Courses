using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MilesToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            var miles = double.Parse(Console.ReadLine());
            var kilometers = miles * 1.60934;

            Console.WriteLine("{0:f2}", kilometers);
        }
    }
}

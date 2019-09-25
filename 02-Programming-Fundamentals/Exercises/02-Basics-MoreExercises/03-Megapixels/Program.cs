using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var pixels = width * height;
            var megaPix = pixels / 1000000;

            Console.WriteLine($"{width}x{height} => {Math.Round(megaPix, 1)}MP");
        }
    }
}

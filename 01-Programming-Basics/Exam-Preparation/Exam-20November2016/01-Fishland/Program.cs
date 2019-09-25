using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Fishland
{
    class Program
    {
        static void Main(string[] args)
        {
            double cenaSkumriq = double.Parse(Console.ReadLine());
            double cenaCaca = double.Parse(Console.ReadLine());
            double kgPalamud = double.Parse(Console.ReadLine());
            double kgSafrid = double.Parse(Console.ReadLine());
            double kgMidi = double.Parse(Console.ReadLine());

            double cenaPalamud = (cenaSkumriq + cenaSkumriq * 0.6) * kgPalamud;
            double cenaSafrid = (cenaCaca + cenaCaca * 0.8) * kgSafrid;
            double cenaMidi = kgMidi * 7.5;

            double fullPrice = cenaPalamud + cenaSafrid + cenaMidi;

            Console.WriteLine($"{fullPrice:f2}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CharityCampaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int bakers = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            double sum = (cakes * 45 + waffles * 5.8 + pancakes * 3.2) * bakers * days;
            double finalSum = sum - sum * 0.125;

            Console.WriteLine($"{finalSum:f2}");
        }
    }
}

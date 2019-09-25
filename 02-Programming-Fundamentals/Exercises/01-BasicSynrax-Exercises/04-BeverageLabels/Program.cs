using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_BeverageLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var volume = double.Parse(Console.ReadLine());
            var energy = double.Parse(Console.ReadLine());
            var sugar = double.Parse(Console.ReadLine());

            var fullEnergy = energy * (volume / 100);
            var fullSugar = sugar * (volume / 100);

            Console.WriteLine($"{volume}ml {name}:");
            Console.WriteLine($"{fullEnergy}kcal, {fullSugar}g sugars");
        }
    }
}

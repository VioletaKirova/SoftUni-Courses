using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ChooseADrink
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();

            switch (profession)
            {
                case "Athlete":
                    Console.WriteLine("Water");
                    break;
                case "Businessman":
                case "Businesswoman":
                    Console.WriteLine("Coffee");
                    break;
                case "SoftUni Student":
                    Console.WriteLine("Beer");
                    break;
                default:
                    Console.WriteLine("Tea");
                    break;
            }
        }
    }
}

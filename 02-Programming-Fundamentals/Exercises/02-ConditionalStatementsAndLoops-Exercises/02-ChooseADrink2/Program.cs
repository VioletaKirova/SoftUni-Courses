using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ChooseADrink2
{
    class Program
    {
        static void Main(string[] args)
        {
            var profession = Console.ReadLine();
            var quantity = double.Parse(Console.ReadLine());

            var price = 0.0;

            switch (profession)
            {
                case "Athlete":
                    price = quantity * 0.7;
                    break;
                case "Businessman":
                case "Businesswoman":
                    price = quantity * 1.0;
                    break;
                case "SoftUni Student":
                    price = quantity * 1.7;
                    break;
                default:
                    price = quantity * 1.2;
                    break;
            }

            Console.WriteLine($"The {profession} has to pay {price:f2}.");
        }
    }
}

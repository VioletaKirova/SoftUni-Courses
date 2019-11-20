using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine().ToLower();
            double rows = double.Parse(Console.ReadLine());
            double columns = double.Parse(Console.ReadLine());

            double allSeats = rows * columns;
            double income = 0;

            if (type == "premiere") income = allSeats * 12;
            else if (type == "normal") income = allSeats * 7.5;
            else if (type == "discount") income = allSeats * 5;

            Console.WriteLine($"{income:f2} leva");
        }
    }
}

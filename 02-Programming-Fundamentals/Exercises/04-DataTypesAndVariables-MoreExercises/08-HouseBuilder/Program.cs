using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_HouseBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            int price1 = int.Parse(Console.ReadLine());
            int price2 = int.Parse(Console.ReadLine());

            int intPrice = Math.Max(price1, price2);
            int sbytePrice = Math.Min(price1, price2);

            long totalPrice = (long)intPrice * 10 + sbytePrice * 4;
            Console.WriteLine(totalPrice);
        }
    }
}

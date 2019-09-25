using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int adults = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            string trasport = Console.ReadLine().ToLower();

            double adultTransportFee = 0;
            double studentTransportFee = 0;
            double fullTransportFee = 0;

            double hotelFee = days * 82.99;

            double comissionFee = 0;

            double fullCost = 0;

            if (trasport == "train")
            {
                adultTransportFee = adults * 24.99 * 2;
                studentTransportFee = students * 14.99 * 2;
            }
            else if (trasport == "bus")
            {
                adultTransportFee = adults * 32.5 * 2;
                studentTransportFee = students * 28.5 * 2;
            }
            else if (trasport == "boat")
            {
                adultTransportFee = adults * 42.99 * 2;
                studentTransportFee = students * 39.99 * 2;
            }
            else if (trasport == "airplane")
            {
                adultTransportFee = adults * 70.0 * 2;
                studentTransportFee = students * 50.0 * 2;
            }

            if ((trasport == "train") && (students + adults >= 50))
            {
                fullTransportFee = (adultTransportFee + studentTransportFee) * 0.5;
            }
            else
            {
                fullTransportFee = adultTransportFee + studentTransportFee;
            }

            comissionFee = (fullTransportFee + hotelFee) * 0.1;
            fullCost = fullTransportFee + hotelFee + comissionFee;

            Console.WriteLine($"{fullCost:f2}");
        }
    }
}

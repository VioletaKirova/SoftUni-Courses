using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_For_Football_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            double allMoney = double.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            double numberOfPeople = double.Parse(Console.ReadLine());

            double moneyForTransport = 0.0;
            double moneyForTickets = 0.0;
            double priceOfAllVIPTickets = numberOfPeople * 499.99;
            double priceOfAllNormalTickets = numberOfPeople * 249.99;
            double moneyLeft = 0.0;
            double moneyNeeded = 0.0;


            if (numberOfPeople >= 1 && numberOfPeople <= 4)
            {
                moneyForTransport = allMoney * 75 / 100;
            }
            else if (numberOfPeople >= 5 && numberOfPeople <= 9)
            {
                moneyForTransport = allMoney * 60 / 100;
            }
            else if (numberOfPeople >= 10 && numberOfPeople <= 24)
            {
                moneyForTransport = allMoney * 50 / 100;
            }
            else if (numberOfPeople >= 25 && numberOfPeople <= 49)
            {
                moneyForTransport = allMoney * 40 / 100;
            }
            else if (numberOfPeople > 49)
            {
                moneyForTransport = allMoney * 25 / 100;
            }

            moneyForTickets = allMoney - moneyForTransport;

            if (type == "VIP")
            {
                if (moneyForTickets > priceOfAllVIPTickets)
                {
                    moneyLeft = moneyForTickets - priceOfAllVIPTickets;
                    Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
                }
                else
                {
                    moneyNeeded = priceOfAllVIPTickets - moneyForTickets;
                    Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
                }
            }

            if (type == "Normal")
            {
                if (moneyForTickets > priceOfAllNormalTickets)
                {
                    moneyLeft = moneyForTickets - priceOfAllNormalTickets;
                    Console.WriteLine($"Yes! You have {moneyLeft:f2} leva left.");
                }
                else
                {
                    moneyNeeded = priceOfAllNormalTickets - moneyForTickets;
                    Console.WriteLine($"Not enough money! You need {moneyNeeded:f2} leva.");
                }
            }
        }
    }
}

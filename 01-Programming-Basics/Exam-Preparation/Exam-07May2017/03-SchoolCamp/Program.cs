using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SchoolCamp
{
    class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine().ToLower();
            string groupType = Console.ReadLine().ToLower();
            int students = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double price = 0;
            string sport = " ";

            if (season == "winter")
            {
                if (groupType == "boys" || groupType == "girls")
                {
                    price = days * students * 9.6;
                }
                else if (groupType == "mixed")
                {
                    price = days * students * 10;
                }
            }
            else if (season == "spring")
            {
                if (groupType == "boys" || groupType == "girls")
                {
                    price = days * students * 7.2;
                }
                else if (groupType == "mixed")
                {
                    price = days * students * 9.5;
                }
            }
            else if (season == "summer")
            {
                if (groupType == "boys" || groupType == "girls")
                {
                    price = days * students * 15;
                }
                else if (groupType == "mixed")
                {
                    price = days * students * 20;
                }
            }

            if (students >= 50)
            {
                price -= price * 0.5;
            }
            else if (students >= 20 && students < 50)
            {
                price -= price * 0.15;
            }
            else if (students >= 10 && students < 20)
            {
                price -= price * 0.05;
            }

            if (groupType == "girls")
            {
                if (season == "winter")
                {
                    sport = "Gymnastics";
                }
                else if (season == "spring")
                {
                    sport = "Athletics";
                }
                else if (season == "summer")
                {
                    sport = "Volleyball";
                }
            }
            else if (groupType == "boys")
            {
                if (season == "winter")
                {
                    sport = "Judo";
                }
                else if (season == "spring")
                {
                    sport = "Tennis";
                }
                else if (season == "summer")
                {
                    sport = "Football";
                }
            }
            else if (groupType == "mixed")
            {
                if (season == "winter")
                {
                    sport = "Ski";
                }
                else if (season == "spring")
                {
                    sport = "Cycling";
                }
                else if (season == "summer")
                {
                    sport = "Swimming";
                }
            }

            Console.WriteLine($"{sport} {price:f2} lv.");
        }
    }
}

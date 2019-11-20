using System;

namespace _04_HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] holidayArgs = Console.ReadLine().Split();

            decimal pricePerDay = decimal.Parse(holidayArgs[0]);
            int days = int.Parse(holidayArgs[1]);
            string seasonStr = holidayArgs[2];

            Season season = new Season();

            switch (seasonStr)
            {
                case "Autumn":
                    season = Season.Autumn;
                    break;
                case "Sprint":
                    season = Season.Spring;
                    break;
                case "Winter":
                    season = Season.Winter;
                    break;
                case "Summer":
                    season = Season.Summer;
                    break;
            }

            DiscountType discount = DiscountType.None;

            if (holidayArgs.Length == 4)
            {
                string discountStr = holidayArgs[3];

                switch (discountStr)
                {
                    case "SecondVisit":
                        discount = DiscountType.SecondVisit;
                        break;
                    case "VIP":
                        discount = DiscountType.VIP;
                        break;
                }
            }

            decimal price = PriceCalculator.CalcHolidayPrice(pricePerDay,days, season, discount);
            Console.WriteLine($"{price:f2}");
        }
    }
}

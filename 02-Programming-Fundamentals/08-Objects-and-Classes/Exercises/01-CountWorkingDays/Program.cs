using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _01_CountWorkingDays
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] officialHolidays = new DateTime[]
            {
                 new DateTime(endDate.Year, 01, 1),
                 new DateTime(endDate.Year, 03, 3),
                 new DateTime(endDate.Year, 05, 1),
                 new DateTime(endDate.Year, 05, 6),
                 new DateTime(endDate.Year, 05, 24),
                 new DateTime(endDate.Year, 09, 6),
                 new DateTime(endDate.Year, 09, 22),
                 new DateTime(endDate.Year, 11, 1),
                 new DateTime(endDate.Year, 12, 24),
                 new DateTime(endDate.Year, 12, 25),
                 new DateTime(endDate.Year, 12, 26),
            };

            int workingDaysCounter = 0;

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                bool isHoliday = false;

                for (int i = 0; i < officialHolidays.Length; i++)
                {
                    DateTime tempHolidayCheck = officialHolidays[i];

                    if (currentDate.Day == tempHolidayCheck.Day && currentDate.Month == tempHolidayCheck.Month)
                    {
                        isHoliday = true;
                    }
                }

                if (!isHoliday)
                {
                    workingDaysCounter++;
                }
            }

            Console.WriteLine(workingDaysCounter);
        }
    }
}
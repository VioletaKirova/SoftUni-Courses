using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_WeatherForecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            string weather = "";

            try
            {
                sbyte fitsSbyte = sbyte.Parse(number);
                weather = "Sunny";            

            }
            catch (Exception)
            {
            }

            if (weather == "")
            {
                try
                {
                    int fitsInt = int.Parse(number);
                    weather = "Cloudy";
                }
                catch (Exception)
                {
                }
            }

            if (weather == "")
            {
                try
                {
                    long fitsLong = long.Parse(number);
                    weather = "Windy";
                }
                catch (Exception)
                {
                }
            }

            if (weather == "")
            {
                try
                {
                    double fitsDouble = double.Parse(number);
                    weather = "Rainy";
                }
                catch (Exception)
                {
                }
            }

            Console.WriteLine(weather);
        }
    }
}

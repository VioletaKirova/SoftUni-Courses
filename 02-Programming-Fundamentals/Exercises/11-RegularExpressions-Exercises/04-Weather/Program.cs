using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04_Weather
{
    class Program
    {
        class TemperatureAndWeather
        {
            public double AverageTemp { get; set; }
            public string TypeOfWeather { get; set; }
        }

        static void Main(string[] args)
        {
            string regex = @"([A-Z][A-Z])(\d+\.\d+)([A-Za-z]+)\|";
            string text = "";
            string input = Console.ReadLine();

            while (input != "end")
            {
                text += input;
                input = Console.ReadLine();
            }

            MatchCollection matches = Regex.Matches(text, regex);
            var cities = new Dictionary<string, TemperatureAndWeather>();

            foreach (Match match in matches)
            {
                string nameOfTheCity = match.Groups[1].Value;
                double temperature = double.Parse(match.Groups[2].Value);
                string weather = match.Groups[3].Value;
                var city = new TemperatureAndWeather();
                city.AverageTemp = temperature;
                city.TypeOfWeather = weather;
                cities[nameOfTheCity] = city;
            }

            foreach (var city in cities.OrderBy(c => c.Value.AverageTemp))
            {
                Console.WriteLine($"{city.Key} => {city.Value.AverageTemp:f2} => {city.Value.TypeOfWeather}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AdvertisementMessage
{
    class Program
    {
        static string[] GetPhrases()
        {
            string[] phrases = new string[] 
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."
            };

            return phrases;
        }

        static string[] GetEvents()
        {
            string[] events = new string[] 
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            return events;
        }

        static string[] GetAuthors()
        {
            string[] authors = new string[] 
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            return authors;
        }

        static string[] GetCities()
        {
            string[] cities = new string[] 
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };

            return cities;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            string[] phrases = GetPhrases();
            string[] events = GetEvents();
            string[] autors = GetAuthors();
            string[] cities = GetCities();

            for (int i = 0; i < n; i++)
            {
                int indexPhrase = rnd.Next(phrases.Length);
                int indexEvent = rnd.Next(events.Length);
                int indexAutor = rnd.Next(autors.Length);
                int indexCity = rnd.Next(cities.Length);

                Console.WriteLine($"{phrases[indexPhrase]} {events[indexEvent]} {autors[indexAutor]} - {cities[indexCity]}");
            }
        }
    }
}
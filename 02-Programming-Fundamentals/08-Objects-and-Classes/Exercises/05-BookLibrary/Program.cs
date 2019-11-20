using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _05_BookLibrary
{
    class Program
    {
        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Publisher { get; set; }
            public DateTime ReleaseDate { get; set; }
            public int Number { get; set; }
            public decimal Price { get; set; }
        }

        class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }


        static void PrintResult(Dictionary<string, decimal> pricesByAuthor)
        {
            foreach (var author in pricesByAuthor.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{author.Key} -> {author.Value:f2}");
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Library library = new Library();
            library.Books = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                List<string> input = Console.ReadLine().Split(' ').ToList();

                Book book = new Book();
                book.Title = input[0];
                book.Author = input[1];
                book.Publisher = input[2];
                book.ReleaseDate = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                book.Number = int.Parse(input[4]);
                book.Price = decimal.Parse(input[5]);

                library.Books.Add(book);
            }

            var pricesByAuthor = new Dictionary<string, decimal>();

            foreach (var book in library.Books)
            {
                if (!pricesByAuthor.ContainsKey(book.Author))
                {
                    pricesByAuthor[book.Author] = 0;
                }

                pricesByAuthor[book.Author] += book.Price;
            }

            PrintResult(pricesByAuthor);
        }
    }
}
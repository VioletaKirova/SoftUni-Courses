using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _06_BookLibraryModification
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

        static void PrintResult(Dictionary<string, DateTime> titleAndDate)
        {
            foreach (var title in titleAndDate.OrderBy(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{title.Key} -> {title.Value:dd.MM.yyyy}");
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

            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            var titleAndDate = new Dictionary<string, DateTime>();

            foreach (var book in library.Books)
            {
                if (!titleAndDate.ContainsKey(book.Title) && book.ReleaseDate > date)
                {
                    titleAndDate[book.Title] = book.ReleaseDate;
                }
            }

            PrintResult(titleAndDate);
        }
    }
}
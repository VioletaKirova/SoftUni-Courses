using System;
using System.Text;

namespace _02_BookShop
{
    public class Book
    {
        protected string title;
        protected string author;
        protected decimal price;

        public Book(string author, string title, decimal price)
        {
            this.Author = author;
            this.Title = title;
            this.Price = price;
        }

        protected string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                title = value;
            }
        }

        protected string Author
        {
            get { return author; }
            set
            {
                if (CheckSecondName(value))
                {
                    throw new ArgumentException("Author not valid!");
                }

                author = value;
            }
        }
       
        protected virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value <= (decimal)0.0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Title: {this.Title}")
                .AppendLine($"Author: {this.Author}")
                .AppendLine($"Price: {this.Price:f2}");

            return result.ToString().TrimEnd();
        }

        private bool CheckSecondName(string fullName)
        {
            string[] nameParts = fullName
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameParts.Length > 1 && char.IsDigit(nameParts[1][0]))
            {
                return true;
            }

            return false;
        }
    }
}

using System;

namespace _02_BookShop
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            :base(author, title, price)
        {

        }

        protected override decimal Price
        {
            get { return base.Price * (decimal)1.3; }
        }
    }
}

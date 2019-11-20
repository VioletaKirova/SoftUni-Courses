using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _05_DateModifier
{
    public class Date
    {
        private DateTime dateTime;

        public Date(string input)
        {
            this.DateTime = DateTime.ParseExact(input, "yyyy MM dd", CultureInfo.InvariantCulture);
        }

        public DateTime DateTime
        {
            get { return this.dateTime; }
            set { this.dateTime = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Call(string number)
        {
            if (number.Any(x => !char.IsDigit(x)))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine($"Calling... {number}");
            }
        }

        public void Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine($"Browsing: {site}!");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_1000DaysAfterBirth
{
    class Program
    {
        static void Main(string[] args)
        {
            string birthDay = Console.ReadLine();
            string format = "dd-MM-yyyy";

            DateTime paresedDay = DateTime.ParseExact(birthDay, format, null);
            paresedDay = paresedDay.AddDays(999);

            Console.WriteLine(paresedDay.ToString(format));
        }
    }
}

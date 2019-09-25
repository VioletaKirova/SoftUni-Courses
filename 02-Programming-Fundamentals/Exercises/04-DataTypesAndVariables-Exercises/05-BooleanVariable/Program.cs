using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BooleanVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            bool convertedStr = Convert.ToBoolean(str);

            if (convertedStr)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}

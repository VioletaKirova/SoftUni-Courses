using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_DecryptingMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string message = "";

            for (int i = 0; i < n; i++)
            {
                char character = char.Parse(Console.ReadLine());
                int asciiNum = (int)character + key;
                message += $"{(char)asciiNum}";
            }

            Console.WriteLine(message);
        }
    }
}

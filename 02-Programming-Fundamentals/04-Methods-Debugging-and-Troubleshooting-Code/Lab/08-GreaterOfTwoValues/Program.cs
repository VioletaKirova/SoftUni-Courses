using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string max = GetMax(first, second);
                Console.WriteLine(max);
            }
        }

        static int GetMax(int first, int second)
        {
            int max = 0;

            if (first >= second)
            {
                max = first;
            }
            else
            {
                max = second;
            }

            return max;
        }

        static char GetMax(char first, char second)
        {
            char max = ' ';

            if ((int)first >= (int)second)
            {
                max = first;
            }
            else
            {
                max = second;
            }

            return max;
        } 

        static string GetMax(string first, string second)
        {
            string max = " ";

            if (first.CompareTo(second) >= 0)
            {
                max = first;
            }
            else
            {
                max = second;
            }

            return max;
        }
    }
}

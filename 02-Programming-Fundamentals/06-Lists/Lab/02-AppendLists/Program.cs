using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> results = new List<char>();
            string[] tokens = Console.ReadLine().Split('|').ToArray();

            for (int i = tokens.Length - 1; i >= 0; i--)
            {
                foreach (var token in tokens[i])
                {
                    if (token != ' ')
                    {
                        results.Add(token);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
using System;
using System.Collections.Generic;

namespace _01_UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> uniqueNames = new Dictionary<string, int>(n);

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();

                if (!uniqueNames.ContainsKey(name))
                {
                    uniqueNames.Add(name, 1);
                }
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name.Key);
            }
        }
    }
}

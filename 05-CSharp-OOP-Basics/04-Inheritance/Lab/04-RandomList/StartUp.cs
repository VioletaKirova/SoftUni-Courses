using System;
using System.Linq;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            int listLen = 10;

            for (int i = 0; i < listLen; i++)
            {
                list.Add($"String {i}");
            }

            while (list.Any())
            {
                string randStr = list.RandomString();
                Console.WriteLine(randStr);
            }
        }
    }
}

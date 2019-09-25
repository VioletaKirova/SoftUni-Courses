using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();

            string[] numbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            for (int i = 0; i < numbers.Length; i++)
            {
                smartphone.Call(numbers[i]);
            }

            for (int i = 0; i < sites.Length; i++)
            {
                smartphone.Browse(sites[i]);
            }
        }
    }
}

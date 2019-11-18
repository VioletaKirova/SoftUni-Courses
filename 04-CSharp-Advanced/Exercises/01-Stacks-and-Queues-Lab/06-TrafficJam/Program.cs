using System;
using System.Collections.Generic;

namespace _06_TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsThatCanPass = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            int count = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    int carsThatWillPass = Math.Min(cars.Count, carsThatCanPass);

                    for (int i = 0; i < carsThatWillPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        count++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

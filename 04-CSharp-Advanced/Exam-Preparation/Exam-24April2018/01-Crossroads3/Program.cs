using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Crossroads3
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            int passedCarsCount = 0;

            Queue<string> carQueue = new Queue<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command != "green")
                {
                    carQueue.Enqueue(command);
                    continue;
                }
                else
                {
                    int currentGreenLight = greenLight;

                    string passingCar = null;

                    while (currentGreenLight > 0 && carQueue.Any())
                    {
                        passingCar = carQueue.Dequeue();
                        currentGreenLight -= passingCar.Length;
                        passedCarsCount++;                        
                    }

                    int freeWindowLeft = freeWindow + currentGreenLight;

                    if (freeWindowLeft < 0)
                    {
                        int charsThatDidntPass = Math.Abs(freeWindowLeft);
                        int crashIndex = passingCar.Length - charsThatDidntPass;
                        char hitChar = passingCar[crashIndex];

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{passingCar} was hit at {hitChar}.");

                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCarsCount} total cars passed the crossroads.");
        }
    }
}

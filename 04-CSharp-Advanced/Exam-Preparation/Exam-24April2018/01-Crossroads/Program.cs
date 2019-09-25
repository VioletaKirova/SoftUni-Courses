using System;
using System.Collections.Generic;

namespace _01_Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightTime = int.Parse(Console.ReadLine());
            int freeWindowTime = int.Parse(Console.ReadLine());

            int greenLightTimeLeft = greenLightTime;

            char hitChar = ' ';

            Queue<Queue<char>> carQueue = new Queue<Queue<char>>();

            int crossedCarsCount = 0;

            string command = Console.ReadLine();

            while (command != "END")
            {
                if (command == "green")
                {
                    greenLightTimeLeft = greenLightTime;

                    var currentCar = carQueue.Peek();

                    int currentCarLen = currentCar.Count;

                    while (greenLightTimeLeft > 0)
                    {
                        if (currentCarLen <= greenLightTimeLeft)
                        {
                            crossedCarsCount++;
                            carQueue.Dequeue();

                            greenLightTimeLeft -= currentCarLen;

                            command = Console.ReadLine();

                            if (command != "green" && command != "END")
                            {
                                carQueue.Enqueue(new Queue<char>(command.ToCharArray()));
                            }
                        }
                        else
                        {
                            if (currentCarLen <= greenLightTimeLeft + freeWindowTime)
                            {
                                crossedCarsCount++;
                                carQueue.Dequeue();

                                command = Console.ReadLine();
                                continue;
                            }
                            else
                            {
                                for (int i = 0; i < greenLightTimeLeft + freeWindowTime; i++)
                                {
                                    if (i == greenLightTimeLeft + freeWindowTime - 1)
                                    {
                                        hitChar = currentCar.Dequeue();
                                    }
                                    else
                                    {
                                        currentCar.Dequeue();
                                    }
                                }

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carQueue.Dequeue()} was hit at {hitChar}");
                                break;
                            }
                        }
                    }                  
                }
                else
                {
                    Queue<char> car = new Queue<char>(command.ToCharArray());

                    carQueue.Enqueue(car);
                }

                command = Console.ReadLine();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _01_Crossroads2
{
    // 57/100

    class Program
    {
        static void Main(string[] args)
        {
            int greenLightSecs = int.Parse(Console.ReadLine());
            int freeWindowSecs = int.Parse(Console.ReadLine());

            int greenLightSecsLeft;

            int passedCars = 0;

            bool crash = false;

            Queue<string> carQueue = new Queue<string>();

            string command;

            while (true)
            {
                command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{passedCars} total cars passed the crossroads.");

                    break;
                }
                else if (command.ToLower() != "green")
                {
                    carQueue.Enqueue(command);
                }
                else
                {
                    greenLightSecsLeft = greenLightSecs;

                    while (true)
                    {
                        if (carQueue.Count == 0)
                        {
                            break;
                        }

                        string currentCar = carQueue.Peek();

                        int currentCarLen = currentCar.Length;

                        if (currentCarLen <= greenLightSecsLeft)
                        {
                            carQueue.Dequeue();
                            passedCars++;

                            greenLightSecsLeft -= currentCarLen;
                        }
                        else
                        {
                            if (currentCarLen <= greenLightSecsLeft + freeWindowSecs)
                            {
                                carQueue.Dequeue();
                                passedCars++;
                                break;
                            }
                            else
                            {
                                int hitCharIndex = currentCarLen - (greenLightSecsLeft + freeWindowSecs) + 2;
                                string hitChar = currentCar[hitCharIndex].ToString();

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{carQueue.Dequeue()} was hit at {hitChar}.");

                                crash = true;                           
                                break;
                            }
                        }      
                    }

                    if (crash)
                    {
                        break;
                    }
                }
            }
        }
    }
}

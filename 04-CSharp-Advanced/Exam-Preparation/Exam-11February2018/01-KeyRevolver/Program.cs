using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bullets = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bulletsStack = new Stack<int>(bullets);

            int[] locks = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            Queue<int> locksQueue = new Queue<int>(locks);

            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletCount = 0;
            int gunBarrelCount = 0;

            while (true)
            {
                int currentBullet = bulletsStack.Pop();
                bulletCount++;
                gunBarrelCount++;

                int currentLock = locksQueue.Peek();

                if (currentBullet <= currentLock)
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");

                    if (gunBarrelCount == gunBarrelSize && bulletsStack.Any())
                    {
                        Console.WriteLine("Reloading!");
                        gunBarrelCount = 0;
                    }

                    if ((!locksQueue.Any() && bulletsStack.Any()) || (!locksQueue.Any() && !bulletsStack.Any()))
                    {
                        int earned = intelligenceValue - bulletCount * bulletPrice;
                        Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${earned}");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Ping!");

                    if (gunBarrelCount == gunBarrelSize && bulletsStack.Any())
                    {
                        Console.WriteLine("Reloading!");
                        gunBarrelCount = 0;
                    }
                }
               
                if (!bulletsStack.Any() && locksQueue.Any())
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    break;
                }
            }

        }
    }
}

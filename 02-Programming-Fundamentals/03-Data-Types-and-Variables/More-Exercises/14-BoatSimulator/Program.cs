using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_BoatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int firstBoatSpeed = 0;
            int secondBoatSpeed = 0;
            bool firstBoatWins = false;
            bool secondBoatWins = false;

            for (int i = 1; i <= n; i++)
            {
                string speed = Console.ReadLine();

                if (speed == "UPGRADE")
                {
                    firstBoat = (char)((int)firstBoat + 3);
                    secondBoat = (char)((int)secondBoat + 3);
                }
                else
                {
                    if (i % 2 != 0)
                        firstBoatSpeed += speed.Length;
                    else
                        secondBoatSpeed += speed.Length;

                    if (firstBoatSpeed >= 50 || secondBoatSpeed >= 50)
                    {
                        if (firstBoatSpeed >= 50)
                            firstBoatWins = true;
                        else
                            secondBoatWins = true;
                        break;
                    }

                    if (i == n && firstBoatSpeed < 50 && secondBoatSpeed < 50)
                    {
                        if (firstBoatSpeed > secondBoatSpeed)
                            firstBoatWins = true;
                        else
                            secondBoatWins = true;
                    }
                }
            }

            if (firstBoatWins)
                Console.WriteLine(firstBoat);
            else if (secondBoatWins)
                Console.WriteLine(secondBoat);
        }
    }
}

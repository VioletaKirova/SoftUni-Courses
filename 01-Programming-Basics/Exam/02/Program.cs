using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            double kilosTomatoes = double.Parse(Console.ReadLine());
            double boxes = double.Parse(Console.ReadLine());
            double jars = double.Parse(Console.ReadLine());

            double kilosLutenitsa = kilosTomatoes / 5;
            double neededJars = kilosLutenitsa / 0.535;
            double neededBoxes = neededJars / jars;

            double boxesLeftOrNeeded = 0.0;
            double jarsLeftOrNeeded = 0.0;

            if (neededBoxes > boxes)
            {
                boxesLeftOrNeeded = neededBoxes - boxes;
                jarsLeftOrNeeded = neededJars - (boxes * jars);

                Console.WriteLine($"Total lutenica: {Math.Floor(kilosLutenitsa)} kilograms.");
                Console.WriteLine($"{Math.Floor(boxesLeftOrNeeded)} boxes left.");
                Console.WriteLine($"{Math.Floor(jarsLeftOrNeeded)} jars left.");
            }
            else 
            {
                boxesLeftOrNeeded = boxes - neededBoxes;
                jarsLeftOrNeeded = (boxes * jars) - neededJars;

                Console.WriteLine($"Total lutenica: {Math.Floor(kilosLutenitsa)} kilograms.");
                Console.WriteLine($"{Math.Floor(boxesLeftOrNeeded)} more boxes needed.");
                Console.WriteLine($"{Math.Floor(jarsLeftOrNeeded)} more jars needed.");
            }            
        }
    }
}

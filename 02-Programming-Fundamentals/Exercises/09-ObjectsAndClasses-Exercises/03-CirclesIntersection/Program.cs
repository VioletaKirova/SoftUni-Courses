using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_CirclesIntersection
{
    // 58/100
    class Program
    {
        class Circle
        {
            public int Center { get; set; }
            public int Radius { get; set; }
        }

        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static int[] ReadCircle()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Circle c = new Circle();
            Point p = new Point();
            input[0] = p.X;
            input[1] = p.Y;
            input[2] = c.Radius;
            return input;
        }

        static double CalcDistance(int[] c1, int[] c2)
        {
            double deltaX = c2[0] - c1[0];
            double deltaY = c2[1] - c1[1];
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }

        static void Main(string[] args)
        {
            int[] c1 = ReadCircle();
            int[] c2 = ReadCircle();
            double distance = CalcDistance(c1, c2);
            int radiusSum = c1[2] + c2[2];

            if (distance <= radiusSum)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
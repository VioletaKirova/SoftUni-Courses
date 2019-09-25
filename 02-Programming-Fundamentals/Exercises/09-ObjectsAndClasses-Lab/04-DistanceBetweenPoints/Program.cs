using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_DistanceBetweenPoints
{
    class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static Point ReadPoint()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point point = new Point();
            point.X = input[0];
            point.Y = input[1];
            return point;
        }

        static double CalcDistance (Point p1, Point p2)
        {
            int deltaX = p2.X - p1.X;
            int deltaY = p2.Y - p1.Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }

        static void Main(string[] args)
        {
            Point p1 = ReadPoint();
            Point p2 = ReadPoint();

            double distance = CalcDistance(p1, p2);

            Console.WriteLine($"{distance:f3}");
        }
    }
}
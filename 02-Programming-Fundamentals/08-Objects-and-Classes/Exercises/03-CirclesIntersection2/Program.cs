using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_CirclesIntersection2
{
    class Program
    {
        class Circle
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Radius { get; set; }
        }

        static Circle GetCircle()
        {
            double[] input = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Circle c = new Circle();
            c.X = input[0];
            c.Y = input[1];
            c.Radius = input[2];
            return c;
        }

        static double CalcDistance(Circle c1, Circle c2)
        {
            double deltaX = Math.Abs(c2.X - c1.X);
            double deltaY = Math.Abs(c2.Y - c1.Y);
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }

        static double CalcRadiusSum(Circle c1, Circle c2)
        {
            double radiusSum = c1.Radius + c2.Radius;
            return radiusSum;
        }

        static bool Intersect(double distance, double radiusSum)
        {
            if(distance <= radiusSum)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        static void Main(string[] args)
        {
            Circle c1 = GetCircle();
            Circle c2 = GetCircle();

            double distance = CalcDistance(c1, c2);
            double radiusSum = CalcRadiusSum(c1, c2);

            bool intersect = Intersect(distance, radiusSum);

            if (intersect)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
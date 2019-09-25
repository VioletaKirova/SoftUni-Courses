using System;
using System.Linq;

namespace _02_PointInRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = GetCoordinates();

            Point bottomLeft = new Point
                (
                rectangleCoordinates[0],
                rectangleCoordinates[1]
                );

            Point topRight = new Point
                (
                rectangleCoordinates[2],
                rectangleCoordinates[3]
                );

            Rectangle rectangle = new Rectangle(bottomLeft, topRight);

            int pointsCount = int.Parse(Console.ReadLine());

            CheckPoints(rectangle, pointsCount);
        }

        private static void CheckPoints(Rectangle rectangle, int pointsCount)
        {
            for (int i = 0; i < pointsCount; i++)
            {
                int[] pointCoordinates = GetCoordinates();

                Point currentPoint = new Point
                    (
                    pointCoordinates[0],
                    pointCoordinates[1]
                    );

                if (rectangle.Contains(currentPoint))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }

        private static int[] GetCoordinates()
        {
            return Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_RectangleIntersection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();

            int[] input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rectangleCount = input[0];
            int intersectionCount = input[1];

            for (int i = 0; i < rectangleCount; i++)
            {
                string[] rectangleArgs = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string id = rectangleArgs[0];
                double width = double.Parse(rectangleArgs[1]);
                double height = double.Parse(rectangleArgs[2]);
                double x = double.Parse(rectangleArgs[3]);
                double y = double.Parse(rectangleArgs[4]);

                Rectangle rectangle = new Rectangle(id, width, height, x, y);
                rectangles.Add(rectangle);
            }

            for (int i = 0; i < intersectionCount; i++)
            {
                string[] intersectionIds = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Rectangle firstRectangle = rectangles.FirstOrDefault(r => r.Id == intersectionIds[0]);
                Rectangle secondRectangle = rectangles.FirstOrDefault(r => r.Id == intersectionIds[1]);

                if (firstRectangle.Intersects(secondRectangle))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}

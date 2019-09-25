using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_RectanglePosition
{
    class Program
    {
        class Rectangle
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int Right { get { return Left + Width; } }
            public int Bottom { get { return Top + Height; } }

            public bool IsInside(Rectangle other)
            {
                var isInLeft = Left >= other.Left;
                var isInRight = Right <= other.Right;
                var isInsideHorizontal = isInLeft && isInRight;
                var isInTop = Top >= other.Top;
                var isInBottom = Bottom <= other.Bottom;
                var isInsideVertical = isInTop && isInBottom;
                return isInsideHorizontal && isInsideVertical;
            }

        }

        static Rectangle ReadRectangle()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Rectangle rectangle = new Rectangle();
            rectangle.Left = input[0];
            rectangle.Top = input[1];
            rectangle.Width = input[2];
            rectangle.Height = input[3];
            return rectangle;
        }

        static void Main(string[] args)
        {
            Rectangle r1 = ReadRectangle(), r2 = ReadRectangle();
            Console.WriteLine(r1.IsInside(r2) ? "Inside" :
              "Not inside");
        }
    }
}
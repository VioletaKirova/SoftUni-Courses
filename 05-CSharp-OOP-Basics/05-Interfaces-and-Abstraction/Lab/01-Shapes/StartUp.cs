﻿using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            Circle circle = new Circle(radius);
            circle.Draw();

            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, height);
            rectangle.Draw();
        }
    }
}

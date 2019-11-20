using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_GeometryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            switch (figure)
            {
                case "triangle":
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleHeight = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{FindTriangleArea(triangleSide, triangleHeight):f2}");
                    break;
                case "square":
                    double squareSide = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{FindSquareArea(squareSide):f2}");
                    break;
                case "rectangle":
                    double rectangleWidth = double.Parse(Console.ReadLine());
                    double rectangleHeight = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{FindRectangleArea(rectangleWidth, rectangleHeight):f2}");
                    break;
                case "circle":
                    double circleRadius = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{FindCircleArea(circleRadius):f2}");
                    break;
            }
        }

        static double FindTriangleArea(double side, double height)
        {
            double area = side * height * 0.5;
            return area;
        }

        static double FindSquareArea(double side)
        {
            double area = side * side;
            return area;
        }

        static double FindRectangleArea(double width, double height)
        {
            double area = width * height;
            return area;
        }

        static double FindCircleArea(double radius)
        {
            double area = Math.PI * (radius * radius);
            return area;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_LongerLine
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());
            double distance1 = FindDistance(x1, y1);
            double distance2 = FindDistance(x2, y2);
            double distance3 = FindDistance(x3, y3);
            double distance4 = FindDistance(x4, y4);
            double length1 = distance1 + distance2;
            double length2 = distance3 + distance4;
            string longerLineStr = "";

            if (length1 >= length2)
            {
                if (distance1 <= distance2)
                {
                    longerLineStr = $"({x1}, {y1})({x2}, {y2})";
                }
                else
                {
                    longerLineStr = $"({x2}, {y2})({x1}, {y1})";
                }
            }
            else
            {
                if (distance3 <= distance4)
                {
                    longerLineStr = $"({x3}, {y3})({x4}, {y4})";
                }
                else
                {
                    longerLineStr = $"({x4}, {y4})({x3}, {y3})";
                }
            }

            Console.WriteLine(longerLineStr);
        }

        static double FindDistance(double x, double y)
        {
            double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return distance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CenterPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            string closestPoints = FindClosestPoints(x1, y1, x2, y2);
            Console.WriteLine(closestPoints);
        }

        static string FindClosestPoints(double x1, double y1, double x2, double y2)
        {
            string closestPoints = "";
            double distance1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            double distance2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));

            if (distance1 <= distance2)
            {
                closestPoints = $"({x1}, {y1})";
            }
            else
            {
                closestPoints = $"({x2}, {y2})";
            }

            return closestPoints;
        }

        //static string FindClosestPoints(double x1, double y1, double x2, double y2)
        //{
        //    string closestPoints = "";
        //
        //    if ((Math.Abs(x1) <= Math.Abs(x2)) && (Math.Abs(y1) <= Math.Abs(y2)))
        //    {
        //        closestPoints = $"({x1}, {y1})";
        //    }
        //    else if ((Math.Abs(x1) > Math.Abs(x2)) && (Math.Abs(y1) > Math.Abs(y2)))
        //    {
        //        closestPoints = $"({x2}, {y2})";
        //    }      
        //
        //    return closestPoints;
        //}
    }
}

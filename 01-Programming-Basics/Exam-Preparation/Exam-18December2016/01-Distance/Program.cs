using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstSpeed = double.Parse(Console.ReadLine());
            double firstTimeInMin = double.Parse(Console.ReadLine());
            double secondTimeInMin = double.Parse(Console.ReadLine());
            double thirdTimeInMin = double.Parse(Console.ReadLine());

            double firstTimeInH = firstTimeInMin / 60;
            double secondTimeInH = secondTimeInMin / 60;
            double thirdTimeInH = thirdTimeInMin / 60;

            double secondSpeed = firstSpeed + firstSpeed * 0.1;
            double thirdSpeed = secondSpeed - secondSpeed * 0.05;

            double s1 = firstSpeed * firstTimeInH;
            double s2 = secondSpeed * secondTimeInH;
            double s3 = thirdSpeed * thirdTimeInH;

            double s = s1 + s2 + s3;

            Console.WriteLine($"{s:f2}");
        }
    }
}

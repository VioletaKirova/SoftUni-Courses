using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            double takenPictures = double.Parse(Console.ReadLine());
            double filterTime = double.Parse(Console.ReadLine());
            double filterFactor = double.Parse(Console.ReadLine());
            double goodPictures = Math.Ceiling(takenPictures * (filterFactor / 100.0));
            double uploadTime = double.Parse(Console.ReadLine());
            double totalTime = (takenPictures * filterTime) + (goodPictures * uploadTime);

            TimeSpan timeFormat = TimeSpan.FromSeconds(totalTime);
            Console.WriteLine("{0:d1}:{1:d2}:{2:d2}:{3:d2}", timeFormat.Days, timeFormat.Hours, timeFormat.Minutes, timeFormat.Seconds);
        }
    }
}

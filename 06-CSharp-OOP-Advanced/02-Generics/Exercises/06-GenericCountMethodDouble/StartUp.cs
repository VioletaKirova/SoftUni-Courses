namespace _06_GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<Box<double>> boxes = new List<Box<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double elementValue = double.Parse(Console.ReadLine());
                Box<double> box = new Box<double>(elementValue);
                boxes.Add(box);
            }

            double elementValueToCompare = double.Parse(Console.ReadLine());
            int result = Comparator.FindGreaterElements(boxes, elementValueToCompare);
            Console.WriteLine(result);
        }
    }
}

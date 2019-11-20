namespace _05_GenericCountMethodString
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string elementValue = Console.ReadLine();
                Box<string> box = new Box<string>(elementValue);
                boxes.Add(box);
            }

            string elementValueToCompare = Console.ReadLine();
            int result = Comparator.FindGreaterElements(boxes, elementValueToCompare);
            Console.WriteLine(result);
        }
    }
}

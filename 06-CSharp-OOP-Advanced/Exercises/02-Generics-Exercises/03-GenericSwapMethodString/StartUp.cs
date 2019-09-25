namespace _03_GenericSwapMethodString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

            int[] indexes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            ElementSwapper.SwapElements(boxes, firstIndex, secondIndex);

            foreach (var box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}

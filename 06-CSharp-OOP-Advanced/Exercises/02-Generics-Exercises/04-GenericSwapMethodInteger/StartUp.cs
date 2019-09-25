namespace _04_GenericSwapMethodInteger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IList<Box<int>> boxes = new List<Box<int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int elementValue = int.Parse(Console.ReadLine());
                Box<int> box = new Box<int>(elementValue);
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
